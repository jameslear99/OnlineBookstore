using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//thsi model is used as an in between between the controllers and the html pages. It passes the data to the html pages seperate from the controllers

namespace OnlineBookstore.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
