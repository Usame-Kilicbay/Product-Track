using ProductTrack.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProductTrack.Controllers
{
    public class ProductController : Controller
    {
        private ProductTrackEntities productTrackEntities = new ProductTrackEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(productTrackEntities.TBL_Products.ToList());
        }

        [HttpGet]
        public ActionResult AddNewProduct()
        {
            ViewBag.categories = (from i in productTrackEntities.TBL_Categories.ToList()
                                  select new SelectListItem
                                  {
                                      Value = i.CategoryID.ToString(),
                                      Text = i.CategoryName
                                  }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult AddNewProduct(TBL_Products products)
        {
            if (!ModelState.IsValid)
                return View("AddNewProduct");

            TBL_Categories category = productTrackEntities.TBL_Categories.Where(c => c.CategoryID == products.TBL_Categories.CategoryID).FirstOrDefault();
            products.TBL_Categories = category;
            category.CategoryStatus = true;
            productTrackEntities.TBL_Products.Add(products);
            productTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult LoadProduct(int id)
        {
            ViewBag.categories = ViewBag.categories = (from i in productTrackEntities.TBL_Categories.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Value = i.CategoryID.ToString(),
                                                           Text = i.CategoryName
                                                       }).ToList();

            return View("LoadProduct", productTrackEntities.TBL_Products.Find(id));
        }

        public ActionResult UpdateProduct(TBL_Products product)
        {
            TBL_Products updatedProduct = productTrackEntities.TBL_Products.Find(product.ProductID);
            updatedProduct.ProductName = product.ProductName;
            updatedProduct.TBL_Categories = productTrackEntities.TBL_Categories.Where(c => c.CategoryID == product.TBL_Categories.CategoryID).FirstOrDefault();
            updatedProduct.ProductPrice = product.ProductPrice;
            productTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PacifyProduct(int id)
        {
            TBL_Products updatedProduct = productTrackEntities.TBL_Products.Find(id);
            updatedProduct.ProductStatus = false;
            productTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ActivateProduct(int id)
        {
            TBL_Products updatedProduct = productTrackEntities.TBL_Products.Find(id);
            updatedProduct.ProductStatus = true;
            productTrackEntities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}