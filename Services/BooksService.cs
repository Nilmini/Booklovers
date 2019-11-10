using System;
using Booklovers.Data;
using Booklovers.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Booklovers.Service
{
    /**
    * This class is a helper clas for the controllers. Common methods will be written in here.
    */
    public class BooksService
    {
        // This returns all authors in the database
        public SelectList getAuthors(BookloverBookContext context)
        {
            IQueryable<Author> authorsQuery = from m in context.Author
                                              orderby m.Name
                                              select m;
            return new SelectList(authorsQuery, "Id", "Name");
        }
    }
}