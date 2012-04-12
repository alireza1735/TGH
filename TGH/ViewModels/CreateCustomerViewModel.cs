using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using TGH.Models;

namespace TGH.ViewModels
{
    public class CreateCustomerViewModel
    {
        public Customer Customer { get; set; }
        public RegisterModel RegisterModel { get; set; }
        public AccessControl AccessControl { get; set; }
    }
}