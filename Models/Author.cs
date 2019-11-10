using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Booklovers.Models
{
    public class Author : ModelBase
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(1000, MinimumLength = 10)]
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}