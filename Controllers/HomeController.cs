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

        public IActionResult Index(string category, int page = 1)
        {
            //Makes sure that the model is valid before it runs, if not returns the same view as before with the error message
            if (ModelState.IsValid)
            {
                return View(new BookListViewModel
                {
                    //This is where the function of the category buttons are built, 
                    //making it so that the category button of each type selects all the same
                    //books of that category
                    Books = _repository.Books
                        .Where(b => category == null || b.category == category)
                        .OrderBy(b => b.BookID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                    ,
                    PagingInfo = new PagingInfo
                    //This is where the number of pages returned is calculated when filtered for 
                    //a specific category
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = category == null ? _repository.Books.Count() : 
                            _repository.Books.Where(b => b.category == category).Count()
                    },
                    CurrentCategory = category

            });;

                
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
