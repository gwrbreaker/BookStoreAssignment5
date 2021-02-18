using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models
{
    public class BookstoreDbContext : DbContext
    {
        //This is where the database context of type database context is passed to the base
        public BookstoreDbContext (DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }
        //Get and set the Database set of type books 
        public DbSet<Books> Books { get; set; }
    }
}
