using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Test.Data;
using Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Test.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _DbContext;

        public AccountController(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _DbContext.Users.FirstOrDefaultAsync(x => x.Username.Equals(model.Username) && x.Password.Equals(model.Password));
                if (result == null)
                {
                    ModelState.AddModelError(string.Empty, "Không đúng thông tin.");
                    return View(model);
                }
                HttpContext.Session.SetString("user", result.FullName);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}
