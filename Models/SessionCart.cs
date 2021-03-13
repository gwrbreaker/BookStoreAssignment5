﻿using BookStoreAssignment5.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models
{
    public class SessionCart : Cart
    {
        //This starts the cart session so that as long as the program is running the data added to the cart is saved
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;

        }

        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Books books, int quantity)
        {
            base.AddItem(books, quantity);
            Session.SetJson("Cart", this);
        }
        //The override function to remove items from the JSON file that makes up the cart page
        public override void RemoveLine(Books books)
        {
            base.RemoveLine(books);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
