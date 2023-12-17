using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Security.Claims;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LoginController : Controller
    {
        private readonly IService<User> _service;

        public LoginController(IService<User> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email,string password)
        {
            try
            {
                var account = _service.Get(u => u.Email == email && u.Password == password && u.ActiveRatio == true);
                if (account == null)
                {
                    TempData["Mesaj"] = "Giriş Başarısız!";
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,account.Firstname),
                        new Claim("Role","Admin")
                    };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin");
                }

            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }
    }
}
