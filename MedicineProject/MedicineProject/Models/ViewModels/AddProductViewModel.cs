﻿namespace MedicineProject.Models.ViewModels
{
    public class AddProductViewModel
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public int InStock { get; set; }

        public decimal Price { get; set; }

        public string Unit { get; set; }

        public IFormFile Photo { get; set; }
    }
}
