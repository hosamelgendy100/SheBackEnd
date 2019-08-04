using She.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace She.Data.Dtos
{
    public class SubCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
