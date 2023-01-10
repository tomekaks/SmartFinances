using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartFinances.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId { get => GetUsersId(); }

        private string GetUsersId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
