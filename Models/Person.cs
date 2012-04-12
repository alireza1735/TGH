using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Models
{
    public class Person
    {
        public int PersonID { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
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
    }
}
