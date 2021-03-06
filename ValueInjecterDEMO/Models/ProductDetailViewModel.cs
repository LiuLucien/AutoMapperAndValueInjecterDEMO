﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ValueInjecterDEMO.Models
{
    /// <summary>
    /// ProductViewModel
    /// </summary>
    public class ProductDetailViewModel
    {
        ///<summary>
        ///流水識別碼
        ///<summary>
        ///<remarks>Identity Specification Is Identity</remarks>
        public int Id { get; set; }

        ///<summary>
        ///CategoryName
        ///<summary>
        [Display(Name = "類別名稱")]
        public string CategoryName { get; set; }

        ///<summary>
        ///商品名稱
        ///<summary>
        [Display(Name = "商品名稱")]
        [Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string Name { get; set; }

        ///<summary>
        ///商品編號
        ///<summary>
        [Display(Name = "商品編號")]
        [Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(20, ErrorMessage = "{0}長度不可超過20。")]
        public string SerialNo { get; set; }

        ///<summary>
        ///商品屬性
        ///<summary>
        [Display(Name = "商品屬性")]
        [Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string Attribute { get; set; }

        ///<summary>
        ///原價
        ///<summary>
        [Display(Name = "原價")]
        [Required(ErrorMessage = "{0}欄位必填")]
        public int Price { get; set; }

        ///<summary>
        ///售價
        ///<summary>
        [Display(Name = "售價")]
        public int? PromotionPrice { get; set; }

        ///<summary>
        ///可購買商品數
        ///<summary>
        [Display(Name = "可購買商品數")]
        [Required(ErrorMessage = "{0}欄位必填")]
        public int LimitCount { get; set; }

        ///<summary>
        ///商品規格
        ///<summary>
        [Display(Name = "商品規格")]
        [Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(255, ErrorMessage = "{0}長度不可超過255。")]
        public string SpecNote { get; set; }

        ///<summary>
        ///商品說明
        ///<summary>
        [Display(Name = "商品說明")]
        public string Description { get; set; }

        ///<summary>
        ///上架時間
        ///<summary>
        [Display(Name = "上架時間")]
        [DisplayFormat(DataFormatString = "{0}欄位必填", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0}欄位必填")]
        public DateTime ActiveSDate { get; set; }

        ///<summary>
        ///下架時間
        ///<summary>
        [Display(Name = "下架時間")]
        [DisplayFormat(DataFormatString = "{0}欄位必填", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0}欄位必填")]
        public DateTime ActiveEDate { get; set; }

        ///<summary>
        ///允許上架狀態（True：允許，False：不允許）
        ///<summary>
        [Display(Name = "允許上架狀態")]
        [Required(ErrorMessage = "{0}欄位必填")]
        public bool ActiveEnable { get; set; }

        ///<summary>
        ///刪除狀態
        ///<summary>
        [Display(Name = "刪除狀態")]
        [Required(ErrorMessage = "{0}欄位必填")]
        public bool IsDelete { get; set; }

        ///<summary>
        ///建立時間
        ///<summary>
        [Display(Name = "建立時間")]
        [Required(ErrorMessage = "{0}欄位必填")]
        public DateTime CreatedOnUtc { get; set; }

        ///<summary>
        ///異動時間
        ///<summary>
        [Display(Name = "異動時間")]
        [Required(ErrorMessage = "{0}欄位必填")]
        public DateTime? ModifiedOnUtc { get; set; }
    }
}