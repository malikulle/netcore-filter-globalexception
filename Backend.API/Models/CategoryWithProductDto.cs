using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.API.Models
{
    public class CategoryWithProductDto 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
