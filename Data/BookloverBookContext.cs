using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Booklovers.Models;

namespace Booklovers.Data
{
    public class BookloverBookContext : DbContext
    {
        public BookloverBookContext(DbContextOptions<BookloverBookContext> options)
            : base(options)
        {
            // this.LazyLoadingEnabled = false;
        }

        public DbSet<Booklovers.Models.Book> Book { get; set; }
        public DbSet<Booklovers.Models.Author> Author { get; set; }
    }
}

