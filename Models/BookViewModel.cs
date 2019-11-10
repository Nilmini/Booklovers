using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Booklovers.Models
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public SelectList Authors { get; set; }
        public Author Author { get; set; }
    }
}