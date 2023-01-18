using Microsoft.AspNetCore.Mvc;

namespace SmartFinances.Controllers
{
    public class TransfersController : BaseController
    {
        public TransfersController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
