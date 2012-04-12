using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace TGH.Controllers
{
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


     

    }
}
