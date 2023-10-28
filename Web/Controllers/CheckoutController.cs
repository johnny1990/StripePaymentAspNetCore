using Contract;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IService _service;

        public CheckoutController(IService service, IConfiguration configuration)
        {
            _service = service;
        }

        public IActionResult Purchase(Guid id)
        {
            var ts = _service.GetById(id);
            ViewBag.Amount = ts.Price;
            if (ts == null) return NotFound();
            return View(ts);
        }

        [HttpPost]
        public IActionResult New(string stripeToken, Guid id)
        {
            var tshirt = _service.GetById(id);

            var chargeOptions = new ChargeCreateOptions()
            {
                Amount = (long)(Convert.ToDouble(tshirt.Price) * 100),
                Currency = "USD",
                Source = stripeToken,
                Metadata = new Dictionary<string, string>()
                {
                    {"Id", tshirt.Id.ToString() },
                    {"Description", tshirt.Description },
                    {"Price", tshirt.Price }
                }
            };

            var service = new ChargeService();
            Charge charge = service.Create(chargeOptions);

            if (charge.Status == "succeeded")
            {
                return View("Success");
            }
            return View("Failure");
        }
    }
}
