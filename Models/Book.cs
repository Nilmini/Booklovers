using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booklovers.Models
{
    public class Book : ModelBase
    {
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
        public Author Author { get; set; }
    }
}