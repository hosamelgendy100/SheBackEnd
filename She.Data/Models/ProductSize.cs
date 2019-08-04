using System.ComponentModel.DataAnnotations;

namespace She.Data.Models
{
    public class ProductSize 
    {
        public int AvailableSizeId { get; set; }
        public int ProductId { get; set; }
        public int ProductSizeCount { get; set; }

        public AvailableSize AvailableSize { get; set; }
        public Product Product { get; set; }
    }
}