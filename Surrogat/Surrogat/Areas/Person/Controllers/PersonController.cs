using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using Surrogat.Areas.CentralBank.Services;
using Surrogat.Areas.Issuer.Services;
using Surrogat.Areas.Person.Repository;
using Surrogat.Areas.Person.ViewModels;
using Surrogat.Shared;

namespace Surrogat.Areas.Person.Controllers
{
    public class PersonController : Controller
    {
        private VirtualAtmService _virtualAtmService;
        private ExchangeEBillService _exchangeEBillService;

        public PersonController()
        {
            _virtualAtmService = new VirtualAtmService();
            _exchangeEBillService = new ExchangeEBillService();
        }

        public ActionResult Index(int personId)
        {
            var model = new PersonViewModel
            {
                Person = new PersonRepository().GetPersonById(personId),
                CashedInToken = (string)TempData["CashedInToken"]
            };

            return this.View("index", model);
        }

        [HttpPost]
        public ActionResult Withdraw(PersonViewModel vm)
        {
            var bill = _virtualAtmService.WithdrawBill(vm.Person.Id, vm.Amount);
            new PersonRepository().AddEBill(vm.Person.Id, vm.Amount, bill.Token);

            return RedirectToAction("index", new { personId = vm.Person.Id });
        }

        [HttpPost]
        public ActionResult CashIn(PersonViewModel vm)
        {
            var personRepository = new PersonRepository();
            var person = personRepository.GetPersonById(vm.Person.Id);
            var uncashedTokens = person.EBills.Where(t => !t.Cashed).Select(t => t.Token).ToList();
            var eBills = _exchangeEBillService.Exchange(uncashedTokens, vm.Amount).ToList();
            personRepository.CashInBills(uncashedTokens);
            foreach (var bill in eBills)
            {
                personRepository.AddEBill(vm.Person.Id, bill.Amout, bill.Token);
            }

            var eBill = eBills.SingleOrDefault(b => b.Amout == vm.Amount);
            TempData["CashedInToken"] = eBill != null ? eBill.Token.ToString() : null;

            return RedirectToAction("index", new { personId = vm.Person.Id });
        }

        /*private FileStreamResult RenderQRCode(Guid token)
        {
            // generating a barcode here. Code is taken from QrCode.Net library
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.L);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(token.ToString(), out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Four), Brushes.Black, Brushes.White);

            Stream memoryStream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, memoryStream);

            // very important to reset memory stream to a starting position, otherwise you would get 0 bytes returned
            memoryStream.Position = 0;

            var resultStream = new FileStreamResult(memoryStream, "image/png");
            resultStream.FileDownloadName = String.Format("{0}.png", string.Concat("EBill_", DateTime.Now.ToString()));

            return resultStream;
        }*/
    }
}