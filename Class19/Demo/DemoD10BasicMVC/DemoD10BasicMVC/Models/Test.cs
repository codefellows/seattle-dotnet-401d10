using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoD10BasicMVC.Models
{
    public class Test
    {
     
        [Required]
        [DataType(DataType.Text)]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
