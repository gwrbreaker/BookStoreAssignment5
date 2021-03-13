using BookStoreAssignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Components
{
    //This is where the cart summary view component is made by defining the different functions to produce it
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        //The view is returned to be added in
        public IViewComponentResult Invoke ()
        {
            return View(cart);
        }
    }
}
