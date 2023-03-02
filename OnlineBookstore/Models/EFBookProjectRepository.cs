using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class EFBookProjectRepository : IBookProjectRepository
    {

        private BookstoreContext context { get; set; }

        public EFBookProjectRepository(BookstoreContext temp) => context = temp;

        public IQueryable<Book> Books => context.Books;

    }
}
