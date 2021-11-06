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
        ProductTrackEntities ProductTrackEntities = new ProductTrackEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(ProductTrackEntities.TBL_Products.ToList());
        }
    }
}