using ProductTrack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTrack.Controllers
{
    public class ProductController : Controller
    {
        private ProductTrackEntities ProductTrackEntities = new ProductTrackEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(ProductTrackEntities.TBL_Products.ToList());
        }

        [HttpGet]
        public ActionResult AddNewProduct()
        {
            List<SelectListItem> items = (from i in ProductTrackEntities.TBL_Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Value = i.CategoryID.ToString(),
                                              Text = i.CategoryName
                                          }).ToList();

            ViewBag.categories = items;

            return View();
        }

        [HttpPost]
        public ActionResult AddNewProduct(TBL_Products products)
        {
            TBL_Categories category = ProductTrackEntities.TBL_Categories.Where(c => c.CategoryID == products.TBL_Categories.CategoryID).FirstOrDefault();
            products.TBL_Categories = category;
            ProductTrackEntities.TBL_Products.Add(products);
            ProductTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}