using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITIProject.Areas.Dashboard.ViewModels
{
    public class Role
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}