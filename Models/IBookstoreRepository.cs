using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models
{
    public interface IBookstoreRepository
    {
        //Creates an Iqueryable of type books for the repository
        IQueryable<Books> Books { get; }
    }
}
