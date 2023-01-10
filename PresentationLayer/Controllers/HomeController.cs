using BusinessLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;



namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _empService;

        private readonly IGuardService _guardService;
        public HomeController(IEmployeeService empService, IGuardService guardService)
        {
            _empService = empService;
            _guardService = guardService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult show(string fn, string ln)
        {
            return View(_empService.GetEmp(fn, ln));
        }
       
        public IActionResult SignIn()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult Badge(string fn, string ln, int ecode)
        {
            
            _guardService.SignInBadge(fn,ln,ecode);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult SignBadgeout(int id)
        {
            _guardService.SignOutBadge(id);
            
            return RedirectToAction(nameof(Index));
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetBadges()
        {
            return View(_guardService.GetBadges());
        }
        

        [HttpPost]
        public IActionResult GetBadges(string fn, string ln, DateTime start , DateTime end, string Status)
        {
            return View(_guardService.GetBadgeReport(fn, ln, start ,end,Status));

           
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            return View();

        }


        [HttpPost]
        public IActionResult SignOut(string TempBadge)
        {
            _guardService.SignOutPage(TempBadge);
            return RedirectToAction("Index", "Home");

        }


        [Authorize]
        public IActionResult BadgeOut()
        {
            return View(_guardService.GetBadgeOut());
        }

        [Authorize]
        public IActionResult BadgeQueue()
        {
            return View(_guardService.GetBadgeQueue());
        }


    }
}