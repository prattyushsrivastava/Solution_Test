using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _empService;
        public HomeController(IEmployeeService empService)
        {
            _empService = empService;
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
        public IActionResult show(string? fn, string? ln)
        {
            return View(_empService.GetEmp(fn, ln));

            //return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}