using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
