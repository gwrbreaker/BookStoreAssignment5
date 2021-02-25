using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStoreAssignment5.Models;
using BookStoreAssignment5.Models.ViewModels;

namespace BookStoreAssignment5.Controllers
{
    public class HomeController : Controller
    {//Set the number of items that will be displayed per page
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _repository;
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            //Makes the private repository a public repository
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(int page = 1)
        {
            //Makes sure that the model is valid before it runs, if not returns the same view as before with the error message
            if (ModelState.IsValid)
            {
                return View(new BookListViewModel
                {
                    Books = _repository.Books
                        .OrderBy(b => b.BookID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                    ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = _repository.Books.Count()
                    }

            });

                
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
