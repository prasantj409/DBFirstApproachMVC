using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLModel
{
    public class EmployeeModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string email { get; set; }
        [Display(Name = "Address")]
        public int? address_id { get; set; }
        [Required]
        [Display(Name ="Emp Code")]
        public string emp_code { get; set; }

        public virtual AddressModel Address { get; set; }
    }
}
