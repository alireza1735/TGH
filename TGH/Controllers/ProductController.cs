using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.IO;
namespace TGH.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        TGHEntities storeDB = new TGHEntities();
        public ActionResult Index()
        {
            var products = storeDB.Products.Include("ProductStores").ToList();
            return View("Browse",products);
        }

        public ActionResult Browse(string cat)
        {
            string secureCat = Server.HtmlEncode(cat);
            var products = storeDB.Products.Include("ProductStores").Where(p => p.Categorie.Name == secureCat).ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Include("ProductStores").SingleOrDefault(p => p.ProductID == id);
            return View(product);
        }
        
        public FileContentResult getImage(int id)
        {
            byte[] image = storeDB.Products.SingleOrDefault(p => p.ProductID == id).Image;
            if (image == null)
            {
                FileStream fs = System.IO.File.Open(Server.MapPath("~/Content/Image/Chrysanthemum.jpg"), FileMode.Open);
                image = new byte[fs.Length];
                fs.Read(image, 0, (int)fs.Length);
                fs.Close();
            }
            return File(image, "image/jpg");
        }
 
    }
}
