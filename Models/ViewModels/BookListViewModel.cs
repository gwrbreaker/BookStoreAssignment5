using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models.ViewModels
{
    public class BookListViewModel
    {
        //These are the view models for the database of books enumeration, and the information for getting and setting 
        //the paging info
        public IEnumerable<Books> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
