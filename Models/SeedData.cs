using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookstoreDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    new Books
                    {
                        
                        title = "Les Miserables",
                        authorLast = "Hugo",
                        authorFirst = "Victor",
                        publisher = "Signet",
                        ISBN = "978-0451419439",
                        classification = "Fiction",
                        category = "Classic",
                        price = 9.95
                    },
                    new Books
                    {
                        
                        title = "Team of Rivals",
                        authorLast = "Kearns Goodwin",
                        authorFirst = "Doris",
                        publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        classification = "Non-Fiction",
                        category = "Biography",
                        price = 14.58
                    },
                    new Books
                    {
                        
                        title = "The Snowball",
                        authorLast = "Schroeder",
                        authorFirst = "Alice",
                        publisher = "Bantam",
                        ISBN = "978-0553384611",
                        classification = "Non-Fiction",
                        category = "Biography",
                        price = 21.54
                    },
                    new Books
                    {
                        
                        title = "American Ulysses",
                        authorLast = "C. White",
                        authorFirst = "Ronald",
                        publisher = "Random House",
                        ISBN = "978-9812981254",
                        classification = "Non-Ficton",
                        category = "Biography",
                        price = 11.61
                    },
                    new Books
                    {
                        
                        title = "Unbroken",
                        authorLast = "Hillenbrand",
                        authorFirst = "Laura",
                        publisher = "Random House",
                        ISBN = "978-0812974492",
                        classification = "Non-Ficton",
                        category = "Historical",
                        price = 13.33
                    },
                     new Books
                     {
                         
                         title = "The Great Train Robbery",
                         authorLast = "Crichton",
                         authorFirst = "Michael",
                         publisher = "Vintage",
                         ISBN = "978-0804171281",
                         classification = "Ficton",
                         category = "Historical Fiction",
                         price = 15.95
                     },
                      new Books
                      {
                         
                          title = "Deep Work",
                          authorLast = "Newport",
                          authorFirst = "Cal",
                          publisher = "Grand Central Publishing",
                          ISBN = "978-1455586691",
                          classification = "Non-Ficton",
                          category = "Self-Help",
                          price = 14.99
                      },
                       new Books
                       {
                           
                           title = "It's Your Ship",
                           authorLast = "Abrashoff",
                           authorFirst = "Michael",
                           publisher = "Grand Central Publishing",
                           ISBN = "978-1455523023",
                           classification = "Non-Ficton",
                           category = "Self-Help",
                           price = 21.66
                       },
                        new Books
                        {
                            
                            title = "The Virgin Way",
                            authorLast = "Branson",
                            authorFirst = "Richard",
                            publisher = "Portfolio",
                            ISBN = "978-1591847984",
                            classification = "Non-Ficton",
                            category = "Business",
                            price = 29.16
                        },
                         new Books
                         {
                             title = "Sycamore Row",
                             authorLast = "Grisham",
                             authorFirst = "John",
                             publisher = "Bantam",
                             ISBN = "978-0553393613",
                             classification = "Ficton",
                             category = "Thrillers",
                             price = 15.03
                         }


                    );

                context.SaveChanges();
            }
        }
    }
}
