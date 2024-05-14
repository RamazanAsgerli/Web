using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskWeb2.DTOs.AccountDto;
using TaskWeb2.Helper.Account;
using TaskWeb2.Models;

namespace TaskWeb2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid) return View();

            User user = new User()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
            };
            
            var result = await _userManager.CreateAsync(user,registerDto.Password);
            if(!result.Succeeded) 
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                };
                return View();
            }
            await _userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto,string? returnUrl=null)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail);
                if(user is null)
                {
                    ModelState.AddModelError("", "UserOrEmail ve ya password sehvdir");
                    return View();
                }
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);
           if(result.IsLockedOut)
            {
                ModelState.AddModelError("", "Birazdan cehd edin!!");
                return View();
            }
           if (result.Succeeded)
            {
                ModelState.AddModelError("", "UserOrEmail ve ya password sehvdir");
                return View();
            }
            await _signInManager.SignInAsync(user, loginDto.IsRemember);
           if(returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> CreateRole()
        {
            foreach(var item in Enum.GetValues(typeof(UserRole)))
            {
                await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name=item.ToString(),
                });
            }
            return Ok();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
