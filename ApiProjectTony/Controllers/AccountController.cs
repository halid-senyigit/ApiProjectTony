using ApiProjectTony.Extensions;
using ApiProjectTony.Models.ViewModels.DTOs;
using ApiProjectTony.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiProjectTony.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpContext httpContext;
        private readonly IXonaService xonaService;

        public AccountController(
            IHttpContextAccessor httpContext,
            IXonaService xonaService
            )
        {
            this.httpContext = httpContext.HttpContext;
            this.xonaService = xonaService;
        }


        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(httpContext.Session.GetJson<string>("token")))
            {
                return RedirectToAction("Login");
            }


            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO credentials)
        {
            var token = await xonaService.GetUserAsync(credentials);

            httpContext.Session.SetJson<string>("token", token.AuthToken);


            return RedirectToAction("Index");
        }


    }
}
