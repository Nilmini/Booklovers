using System;
using System.ComponentModel.DataAnnotations;

namespace Booklovers.Models
{
    public class ModelBase
    {
        [DataType(DataType.Date)]
        public DateTime CreatedTime { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ModifiedTime { get; set; }
    }
}