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
        public ActionResult AddNewCategory(TBL_Categories category)
        {
            category.CategoryStatus = true;
            ProductTrackEntities.TBL_Categories.Add(category);
            ProductTrackEntities.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult LoadCategory(int id)
        {
            return View("LoadCategory", ProductTrackEntities.TBL_Categories.Find(id));
        }

        public ActionResult UpdateCategory(TBL_Categories category)
        {
            TBL_Categories updatedCategory = ProductTrackEntities.TBL_Categories.Find(category.CategoryID);
            updatedCategory.CategoryName = category.CategoryName;
            ProductTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PacifyCategory(int id)
        {
            TBL_Categories updatedCategory = ProductTrackEntities.TBL_Categories.Find(id);
            updatedCategory.CategoryStatus = false;
            ProductTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ActivateCategory(int id)
        {
            TBL_Categories updatedCategory = ProductTrackEntities.TBL_Categories.Find(id);
            updatedCategory.CategoryStatus = true;
            ProductTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}