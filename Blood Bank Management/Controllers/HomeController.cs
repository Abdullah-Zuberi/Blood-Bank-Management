using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Blood_Bank_Management.Models;
using Blood_Bank_Management.Context;
using Microsoft.EntityFrameworkCore;

namespace Blood_Bank_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BloodBankManagementContext _dbContext;

        public HomeController(ILogger<HomeController> logger, BloodBankManagementContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        [Route("/api/get-bloodbanks")]
        public IActionResult GetBloodBanks()
        {
            var bloodBanks = _dbContext.BloodBank.ToList();
            return Json(bloodBanks);
        }

        public IActionResult BloodBanksList()
        {
            var bloodDonors = _dbContext.BloodBank.ToList();

            return View("BloodBank", bloodDonors);
        }

        public IActionResult AddBloodDonorsView()
        {
            return View("AddBloodDonors");
        }

        public IActionResult AddBloodDonor(BloodBank data)
        {
            _dbContext.BloodBank.Add(data);
            _dbContext.SaveChanges();
            var bloodDonors = _dbContext.BloodBank.ToList();

            return RedirectToAction("BloodBanksList", bloodDonors);
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
    }
}