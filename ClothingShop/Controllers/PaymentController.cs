using ClothingShop.Core.Contracts;
using ClothingShop.Models;
using ClothingShop.PaymentSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IDPay iDPay;
        private readonly IOrderFacade orderFacade;

        public PaymentController(IDPay iDPay, IOrderFacade orderFacade)
        {
            this.iDPay = iDPay;
            this.orderFacade = orderFacade;
        }
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "guest")]
        public async Task<IActionResult> Pay(int orderId, int totalPrice)
        {
            PaymentRequestModel model = new PaymentRequestModel(orderId.ToString());
            model.amount = totalPrice;

            var result = await iDPay.RequestPayment(model);
            if (result.Item2)
            {
                SucessRequestRespons item = result.Item1 as SucessRequestRespons;
                orderFacade.SetTransactionId(orderId, item.id);
                return Redirect(item.link);

            }
            return View();
        }
        public async Task<IActionResult> Verify(ResultPayment model)
        {
            if (model.IsOK == true)
            {
                var res = await iDPay.VerifyPayment(model);
                PaymentInfo info = res as PaymentInfo;
                orderFacade.PaymentDone(info.id, info.track_id);
                //VerifyPayment verifyResult = payment.Verify(model.token.ToString());
                //if (verifyResult.Status == 1)
                //{
                //    orderService.PaymentDone(model.token, verifyResult.transId);
                return Content($"پرداخت با موفقیت انجام شد شماره پیگیری {info.track_id}");
                //}


            }
            return View(model);
        }
    }
}
