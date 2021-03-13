using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

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

        public virtual void RemoveLine(Books books) =>
            Lines.RemoveAll(x => x.Books.BookID == books.BookID);

        public virtual void Clear() => Lines.Clear();

        public double ComputeTotalSum() =>
            Lines.Sum(b => b.Books.price);

        public class CartLine
        {
            public int CartLineId { get; set; }
            public Books Books { get; set; }
            public int Quantity { get; set; }

        }

    }
}
