﻿using Omu.ValueInjecter;
using Omu.ValueInjecter.Injections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ValueInjecterDEMO.Models;


namespace ValueInjecterDEMO.Controllers
{
    public class ProductController : Controller
    {
        private AutoMapperAndValueInjecterDEMOEntities db = new AutoMapperAndValueInjecterDEMOEntities();

        // GET: Product
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.ProductCategory).Where(s => !s.IsDelete).OrderByDescending(s => s.CreatedOnUtc).ToList();
            return View(product);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductDetailViewModel vm = new ProductDetailViewModel();

            #region 使用前
            //vm = new ProductDetailViewModel()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Attribute = product.Attribute,
            //    Price = product.Price,
            //    PromotionPrice = product.PromotionPrice,
            //    LimitCount = product.LimitCount,
            //    SpecNote = product.SpecNote,
            //    Description = product.Description,
            //    ActiveEDate = product.ActiveEDate,
            //    ActiveEnable = product.ActiveEnable,
            //    ActiveSDate = product.ActiveSDate,
            //    CreatedOnUtc = product.CreatedOnUtc,
            //    ModifiedOnUtc = product.ModifiedOnUtc,
            //    IsDelete = product.IsDelete,
            //    CategoryName = product.ProductCategory.Name
            //};
            #endregion
            #region 使用後
            Mapper.AddMap<Product, ProductDetailViewModel>(src =>
            {
                vm.InjectFrom(src);
                vm.CategoryName = src.ProductCategory.Name;
                return vm;
            });
            vm = Mapper.Map<Product, ProductDetailViewModel>(product);

            #endregion

            return View(vm);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductViewModel vm = new ProductViewModel();
            vm.CategoryList = new SelectList(db.ProductCategory, "Id", "Name");
            return View(vm);
        }

        // POST: Product/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                #region 使用前
                //product = new Product()
                //{
                //    Name = vm.SerialNo + vm.Name,
                //    CategoryId = vm.CategoryId,
                //    SpecNote = vm.SpecNote,
                //    Price = vm.Price,
                //    PromotionPrice = vm.PromotionPrice,
                //    LimitCount = vm.LimitCount,
                //    ActiveSDate = vm.ActiveSDate,
                //    ActiveEDate = vm.ActiveEDate,
                //    ActiveEnable = vm.ActiveEnable,
                //    Attribute = vm.Attribute,
                //    Description = vm.Desc,
                //    CreatedOnUtc = DateTime.UtcNow
                //};
                #endregion
                #region 使用後
                ProductDemoModel demo = new ProductDemoModel();

                var vmmapper = new MapperInstance();

                vmmapper.AddMap<ProductViewModel, Product>(src =>
                {
                    product.InjectFrom(new LoopInjection(new[] { nameof(product.Id) }), src);
                    product.Name = src.SerialNo + src.Name;
                    product.Description = src.Desc;
                    product.CreatedOnUtc = DateTime.UtcNow;
                    return product;
                });
                var demomapper = new MapperInstance();

                demomapper.AddMap<ProductDemoModel, Product>(src =>
                {
                    product.InjectFrom(new LoopInjection(new[] { nameof(product.Id) }), src);
                    return product;
                });

                product = vmmapper.Map<ProductViewModel, Product>(vm);
                product = demomapper.Map<ProductDemoModel, Product>(demo);

                db.Product.Add(product);
                #endregion
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.CategoryList = new SelectList(db.ProductCategory, "Id", "Name", vm.CategoryId);
            return View(vm);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductViewModel vm = new ProductViewModel();
            vm.InjectFrom(product);
            vm.CategoryList = new SelectList(db.ProductCategory, "Id", "Name", vm.CategoryId);

            return View(vm);
        }

        // POST: Product/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Product.Find(vm.Id);

                #region 使用前
                //product.Name = vm.SerialNo + vm.Name;
                //product.Price = vm.Price;
                //product.CategoryId = vm.CategoryId;
                //product.Description = vm.Desc;
                //product.ActiveSDate = vm.ActiveSDate;
                //product.ActiveEDate = vm.ActiveEDate;
                //product.ActiveEnable = vm.ActiveEnable;
                //product.Attribute = vm.Attribute;
                //product.LimitCount = vm.LimitCount;
                //product.ModifiedOnUtc = DateTime.UtcNow;
                //product.PromotionPrice = vm.PromotionPrice;
                //product.SpecNote = vm.SpecNote;
                #endregion
                #region 使用後
                Mapper.AddMap<ProductViewModel, Product>(src =>
                {
                    //設定Product的Id不對映
                    product.InjectFrom(new LoopInjection(new[] { nameof(product.Id)}), src);
                    //設定Product的Name對映到ProductViewModel的SerialNo加Name
                    product.Name = src.SerialNo + src.Name;
                    //設定Product的Description對映到ProductViewModel的Desc
                    product.Description = src.Desc;
                    product.ModifiedOnUtc = DateTime.UtcNow;
                    return product;
                });

                product = Mapper.Map<ProductViewModel, Product>(vm, product);
                #endregion

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.CategoryList = new SelectList(db.ProductCategory, "Id", "Name", vm.CategoryId);

            return View(vm);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            product.IsDelete = true;
            db.SaveChanges();
            TempData["message"] = "刪除成功";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
