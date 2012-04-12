using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using TGH.Models;

namespace TGH.ViewModels
{
    public class PaymentViewModel
    {
        public List<Carts> CartItem = new List<Carts>();

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public decimal Total { get; set; }
    }
}