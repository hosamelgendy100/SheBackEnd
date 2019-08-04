using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data.Dtos
{
    public class ProductForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastEdit { get; set; }


        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? UserId { get; set; }
        public int? SellerId { get; set; }
    }
}
