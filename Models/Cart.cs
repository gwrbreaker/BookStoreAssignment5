using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //This is the function to add items to the cart, which it does by the line
        public virtual void AddItem (Books books, int quantity)
        {
            CartLine line = Lines
                .Where(b => b.Books.BookID == books.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Books = books,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        //This is the function to remove items from the cart
        public virtual void RemoveLine(Books books) =>
            Lines.RemoveAll(x => x.Books.BookID == books.BookID);

        public virtual void Clear() => Lines.Clear();
        //This is the function that calculates the total cost based on price and quantity
        public double ComputeTotalSum() =>
            Lines.Sum(b => b.Books.price * b.Quantity);
        //The components of the cart is declared
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Books Books { get; set; }
            public int Quantity { get; set; }

        }

    }
}
