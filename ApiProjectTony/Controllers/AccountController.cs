using ApiProjectTony.Extensions;
using ApiProjectTony.Models.ViewModels;
using ApiProjectTony.Models.ViewModels.DTOs;
using ApiProjectTony.Services.Abstracts;
using ApiProjectTony.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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


        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(httpContext.Session.GetJson<string>("token")))
            {
                return RedirectToAction("Login");
            }

            IList<ContentApiModel> content = await xonaService.GetContentAsync();
            var response = new List<ContentVM>();
            foreach (var item in content)
            {
                ContentVM c = new ContentVM
                {
                    title = item.title,
                    description = item.description,
                    imageUrl = item.image.url
                };
                response.Add(c);
            }
            return View(response);
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
