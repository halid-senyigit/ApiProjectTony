using ApiProjectTony.Models.ViewModels;
using ApiProjectTony.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiProjectTony.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserApiService userApiService;

        public HomeController(IUserApiService userApiService)
        {
            this.userApiService = userApiService;
        }
        public async Task<IActionResult> Index()
        {
            var userFromService = await userApiService.GetUserAsync();

            // can move following code to business layer for mapping, logic etc..
            // can use automapper..
            var user = new UserVM()
            {
                Email = userFromService.results[0].email,
                Gender = userFromService.results[0].gender,
                Name = userFromService.results[0].name.first + " " + userFromService.results[0].name.last
            };

            return View(user);
        }
    }
}
