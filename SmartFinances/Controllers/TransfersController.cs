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

        public async Task<IActionResult> Contacts()
        {
            var model = await _transfersService.GetContactList(UserId);
            return View(model);
        }

        public IActionResult CreateContact()
        {
            var model = new NewContactVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContact(NewContactVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _transfersService.CreateNewContact(model, UserId);

            return RedirectToAction(nameof(Contacts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UseContact(int id)
        {
            
            var model = await _transfersService.UseContact(id);

            return View("NewTransfer", model);
        }

        public async Task<IActionResult> EditContact(int id)
        {
            var model = await _transfersService.GetContact(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContact(EditContactVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _transfersService.EditContact(model);

            return RedirectToAction(nameof(Contacts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContact(int id)
        {

            await _transfersService.DeleteContact(id);

            return RedirectToAction(nameof(Contacts));
        }
    }
}
