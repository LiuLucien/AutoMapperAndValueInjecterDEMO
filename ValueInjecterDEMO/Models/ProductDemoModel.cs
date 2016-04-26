using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ValueInjecterDEMO.Models
{
    /// <summary>
    /// ProductDemoModel
    /// </summary>
    public class ProductDemoModel
    {
        ///<summary>
        ///商品規格
        ///<summary>
        [Display(Name = "商品規格")]
        [Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(255, ErrorMessage = "{0}長度不可超過255。")]
        public string SpecNote { get; set; }

        public ProductDemoModel()
        {
            SpecNote = "多類別對映範例";
        }
    }
}