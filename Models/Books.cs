using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAssignment5.Models
{
    public class Books
    {
        //I know that ASP.NET automatically makes this the key because it has ID, but I added it anyways
        [Required]
        [Key]
        public int BookID { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string authorLast { get; set; }
        [Required]
        public string authorFirst { get; set; }
        [Required]
        public string publisher { get; set; }
        //The regular expression to make the ISBN format ###-##########
        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{10}$", ErrorMessage ="Please enter a valid ISBN")]
        public string ISBN { get; set; }
        [Required]
        public string classification { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public double price { get; set; }
        

    }
}
