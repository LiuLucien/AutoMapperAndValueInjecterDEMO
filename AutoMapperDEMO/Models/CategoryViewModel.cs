using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoMapperDEMO.Models
{
    public class CategoryViewModel
    {
        [Display(Name = "類別名稱")]
        public string Name { get; set; }

        [Display(Name ="商品列表")]
        public List<string> productNames { get; set; }

        public CategoryViewModel()
        {
            productNames = new List<string>();
        }
    }
}