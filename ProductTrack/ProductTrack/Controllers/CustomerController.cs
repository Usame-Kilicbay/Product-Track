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
        private ProductTrackEntities productTrackEntities = new ProductTrackEntities();

        // GET: Customer
        public ActionResult Index()
        {
            return View(productTrackEntities.TBL_Customers.ToList());
        }

        [HttpGet]
        public ActionResult AddNewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCustomer(TBL_Customers customer)
        {
            customer.CustomerStatus = true;
            productTrackEntities.TBL_Customers.Add(customer);
            productTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult LoadCustomer(int id)
        {
            return View("LoadCustomer", productTrackEntities.TBL_Customers.Find(id));
        }

        public ActionResult UpdateCustomer(TBL_Customers customer)
        {
            TBL_Customers updatedCustomer = productTrackEntities.TBL_Customers.Find(customer.CustomerID);
            updatedCustomer.CustomerName = customer.CustomerName;
            productTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PacifyCustomer(int id)
        {
            TBL_Customers updatedCustomer = productTrackEntities.TBL_Customers.Find(id);
            updatedCustomer.CustomerStatus = false;
            productTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ActivateCustomer(int id)
        {
            TBL_Customers updatedCustomer = productTrackEntities.TBL_Customers.Find(id);
            updatedCustomer.CustomerStatus = true;
            productTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}