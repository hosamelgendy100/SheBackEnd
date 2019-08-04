using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data.Dtos
{
    public class SellerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
