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
        public ActionResult AmddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewProduct(TBL_Products products)
        {
            ProductTrackEntities.TBL_Products.Add(products);
            ProductTrackEntities.SaveChanges();

            return View();
        }
    }
}