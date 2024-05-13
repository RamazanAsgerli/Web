using Microsoft.AspNetCore.Mvc;

namespace TaskWeb2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
