using She.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data.Dtos.ProductDtos
{
    public class ProductToDisplayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }
        public DateTime? CreationDate { get; set; } 
        public DateTime? LastEdit { get; set; }
        public bool OnSale { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string UserName { get; set; }
        public string SellerName { get; set; }
    }

  
}
