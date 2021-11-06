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
        ProductTrackEntities ProductTrackEntities = new ProductTrackEntities();

        // GET: Category
        public ActionResult Index()
        {
            return View(ProductTrackEntities.TBL_Categories.ToList());
        }
    }
}