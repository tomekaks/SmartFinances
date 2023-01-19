using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.Transfers;

namespace SmartFinances.Controllers
{
    [Authorize]
    public class TransfersController : BaseController
    {
        private readonly ITransfersService _transfersService;

        public TransfersController(IHttpContextAccessor httpContextAccessor, ITransfersService transfersService) : base(httpContextAccessor)
        {
            _transfersService = transfersService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _transfersService.GetTransfers(UserId);
            return View(model);
        }

        public IActionResult NewTransfer()
        {
            var model = new NewTransferVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewTransfer(NewTransferVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _transfersService.CreateNewTransfer(model, UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}
