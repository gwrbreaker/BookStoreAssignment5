using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models.ViewModels
{
    //All the parts of the dynamic page navigation bar are set and the function to calculate how many pages there 
    //should be is also dynamically calculated
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalNumItems / ItemsPerPage);
    }
}
