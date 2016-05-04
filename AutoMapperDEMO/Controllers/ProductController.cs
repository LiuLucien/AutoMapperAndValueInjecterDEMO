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
using AutoMapperDEMO.Helper;

namespace AutoMapperDEMO.Controllers
{
    public class ProductController : Controller
    {
        private AutoMapperAndValueInjecterDEMOEntities db = new AutoMapperAndValueInjecterDEMOEntities();
        private readonly IAutoMapperConfig _mapper;

        public ProductController(IAutoMapperConfig mapper)
        {
            _mapper = mapper;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Product.Include(p => p.ProductCategory)
                                     .Where(s => !s.IsDelete)
                                     .OrderByDescending(s => s.CreatedOnUtc)
                                     .ToList();

            List<ProductViewModel> vm = _mapper.GetMapper<ProductIndexProfile>().Map<List<ProductViewModel>>(products);

            return View(vm);
        }

        public ActionResult CategoryIndex()
        {
            var category = db.ProductCategory.OrderByDescending(s => s.CreatedOnUtc).ToList();
            return View(category);
        }

        public ActionResult CategoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //類別資料
            var productCategory = db.ProductCategory.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            //屬於該類別的商品資料
            var productNames = db.Product.Where(s => s.CategoryId == id).Select(s => s.Name).ToList();
            var categoryViewModel = new CategoryViewModel();

            IMapper mapper = _mapper.GetMapper<ProductCategoryProfile>();

            //對映類別資料
            mapper.Map(productCategory, categoryViewModel);
            //對映商品資料
            mapper.Map(productNames, categoryViewModel);

            return View(categoryViewModel);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //導覽屬性對映，ProjectTo範例
            MapperConfiguration Config = _mapper.GetConfig<ProductDetailsProfile>();

            ProductDetailViewModel vm = db.Product.ProjectTo<ProductDetailViewModel>(Config).FirstOrDefault(s => s.Id == id);

            if (vm == null)
            {
                return HttpNotFound();
            }
            
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();

                _mapper.GetMapper<ProductCreateProfile>().Map(vm, product);
                db.Product.Add(product);

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
            ProductViewModel vm = _mapper.GetMapper<ProductEditProfile>().Map<ProductViewModel>(product);

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

                if (product != null)
                {
                    _mapper.GetMapper<ProductEditProfile>().Map(vm, product);

                    db.SaveChanges();
                }
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
