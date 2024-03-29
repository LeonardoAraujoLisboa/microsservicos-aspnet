﻿using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models
{
    public class ProductViewModel
    {//copiei do ProductVO obviamente
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Range(1, 100)]
        public int Count { get; set; } = 1;
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string SubstringName ()
        {
            if (Name.Length < 24)
            {
                return Name;
            } 
            else
            {
                return $"{Name.Substring(0, 21)}...";
            }
        }
        public string SubstringDescription()
        {
            if (Name.Length < 355)
            {
                return Description;
            }
            else
            {
                return $"{Name.Substring(0, 352)}...";
            }
        }
    }
}
