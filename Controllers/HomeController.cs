using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStoreAssignment5.Models;

namespace BookStoreAssignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _repository;
        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            //Makes the private repository a public repository
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            //Makes sure that the model is valid before it runs, if not returns the same view as before with the error message
            if (ModelState.IsValid)
            {
                return View(_repository.Books);
            }
            else
            {
                return View();
            }
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
