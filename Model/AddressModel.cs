using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLModel
{
    public class AddressModel
    {
        public int id { get; set; }
        [Display(Name ="Address")]
        [Required]
        public string address1 { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Country")]
        public string country { get; set; }
    }
}
