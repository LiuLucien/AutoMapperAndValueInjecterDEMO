using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapperDEMO.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace AutoMapperDEMO.Controllers
{
    public class ProductController : Controller
    {
        private AutoMapperAndValueInjecterDEMOEntities db = new AutoMapperAndValueInjecterDEMOEntities();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Product.Include(p => p.ProductCategory)
                                     .Where(s => !s.IsDelete)
                                     .OrderByDescending(s => s.CreatedOnUtc)
                                     .ToList();

            IMapper mapper = new MapperConfiguration(c => c.CreateMap<Product, ProductViewModel>()).CreateMapper();

            List<ProductViewModel> vm = mapper.Map<List<ProductViewModel>>(products);

            return View(vm);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductDetailViewModel vm = new ProductDetailViewModel();

            #region 傳統寫法
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

            #region 使用套件的寫法
            //建立類別轉換的設定
            IMapper mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDetailViewModel>();
                c.AddProfile<ProductDetailsProfile>();
            }).CreateMapper();

            vm = mapper.Map<ProductDetailViewModel>(product);
            #endregion

            #region 導覽屬性對映，ProjectTo範例
            //MapperConfiguration Config = new MapperConfiguration(c => c.CreateMap<Product, ProductDetailViewModel>()
            //                                                           .ForMember(s => s.CategoryName,
            //                                                                           a => a.MapFrom(x => x.ProductCategory.Name)));

            //ProductDetailViewModel vm = db.Product.ProjectTo<ProductDetailViewModel>(Config).FirstOrDefault(s => s.Id == id);
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

                #region 傳統寫法
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
                #region 使用套件的寫法
                ProductDemoModel demo = new ProductDemoModel();
                IMapper mapper = new MapperConfiguration(c =>
                {
                    c.CreateMap<ProductViewModel, Product>();
                    c.AddProfile<ProductCreateProfile>();
                }).CreateMapper();

                IMapper mapperDemo = new MapperConfiguration(c => c.CreateMap<ProductDemoModel, Product>()).CreateMapper();

                mapper.Map(vm, product);
                product = mapperDemo.Map(demo, product);
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
            Product product = GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            IMapper mapper = new MapperConfiguration(c => c.CreateMap<Product, ProductViewModel>()).CreateMapper();
            ProductViewModel vm = mapper.Map<ProductViewModel>(product);

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
                Product product = GetProductById(vm.Id);

                #region 傳統寫法
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
                #region 使用套件的寫法
                IMapper mapper = new MapperConfiguration(c =>
                {
                    c.CreateMap<ProductViewModel, Product>();
                    c.AddProfile<ProductEditProfile>();
                }).CreateMapper();
                mapper.Map(vm, product);
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

        private Product GetProductById(int id)
        {
            return db.Product.Include(s => s.ProductCategory).FirstOrDefault(s => s.Id == id);
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
