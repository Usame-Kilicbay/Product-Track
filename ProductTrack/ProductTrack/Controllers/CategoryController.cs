using ProductTrack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTrack.Controllers
{
    public class CategoryController : Controller
    {
        private ProductTrackEntities ProductTrackEntities = new ProductTrackEntities();

        // GET: Category
        public ActionResult Index()
        {
            return View(ProductTrackEntities.TBL_Categories.ToList());
        }

        [HttpGet]
        public ActionResult AddNewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCateogry(TBL_Categories categories)
        {
            ProductTrackEntities.TBL_Categories.Add(categories);
            ProductTrackEntities.SaveChanges();
            
            return View();
        }
    }
}