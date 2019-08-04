using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data.Dtos
{
    public class ProductPhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        // public int ProductId { get; set; }
    }
}
