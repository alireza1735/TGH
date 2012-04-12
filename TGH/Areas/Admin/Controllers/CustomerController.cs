using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TGH.Models;
using Models;
using TGH.ViewModels;
using System.IO;

namespace TGH.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        TGHEntities db = new TGHEntities();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            //var product = db.Products.SingleOrDefault(p => p.ProductID == id);
            //product.Reviews = new List<Review>();
            //product.Reviews.Add(new Review{ Description })
            
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(CreateCustomerViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                RegisterModel registerModel = model.RegisterModel;
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                MembershipUser msu = Membership.CreateUser(registerModel.UserName, registerModel.Password, registerModel.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    model.Customer.Image = new byte[file.ContentLength];
                    file.InputStream.Read(model.Customer.Image, 0, file.ContentLength);
                    model.Customer.UserName = msu.UserName;
                    model.AccessControl.UserName = msu.UserName;
                    db.AccessControls.Add(model.AccessControl);
                    db.Customers.Add(model.Customer);
                    db.SaveChanges();
                    Roles.AddUserToRole(msu.UserName, "Customer"); // create a customer user
                    return View("Complete", model.Customer); //For Develope use this model
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public FileContentResult getImage(string id)
        {
            byte[] image = db.Customers.SingleOrDefault(p => p.UserName == id).Image;
            if (image == null)
            {
                FileStream fs = System.IO.File.Open(Server.MapPath("~/Content/Image/Chrysanthemum.jpg"), FileMode.Open);
                image = new byte[fs.Length];
                fs.Read(image, 0, (int)fs.Length);
                fs.Close();
            }
            return File(image, "image/jpg");
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
