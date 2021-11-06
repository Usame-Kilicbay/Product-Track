using ProductTrack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTrack.Controllers
{
    public class CustomerController : Controller
    {
        private ProductTrackEntities ProductTrackEntities = new ProductTrackEntities();

        // GET: Customer
        public ActionResult Index()
        {
            return View(ProductTrackEntities.TBL_Customers.ToList());
        }
    }
}