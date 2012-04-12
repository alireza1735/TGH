using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace TGH.Areas.Admin.Controllers
{
    [Authorize(Roles="Administrator")]
    public class CategoryController : Controller
    {
        TGHEntities storeDB = new TGHEntities();
        //
        // GET: /Category/

        public ActionResult Index()
        {
            var categories = storeDB.Caegories.ToList();
            return View(categories);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                storeDB.Caegories.Add(categorie);
                storeDB.SaveChanges();
                return RedirectToAction("");
            }
            return View();
        }

    }
}
