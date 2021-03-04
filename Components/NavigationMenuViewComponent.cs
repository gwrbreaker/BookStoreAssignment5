using BookStoreAssignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookstoreRepository repository;

        public NavigationMenuViewComponent (IBookstoreRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //This is where the label of each category tab is built 
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                //These are similar to SQL commands and makes it so that each category is selected,
                //That only 1 distinct instance of each is used, and how they are ordered 
                .Select(b => b.category)
                .Distinct()
                .OrderBy(b => b));
        }
    }
}
