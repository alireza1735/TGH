using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string UserName { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        [DisplayName("Identification Number")]
        public string IDN { get; set; }
        public byte[] Image { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        public string Adress { get; set; }        
        public string Telephone { get; set; }
        public string Mobile { get; set; }

        public List<Caretaker> Caretakers { get; set; }
    }
    public class Caretaker
    {
        public int CaretakerID { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
