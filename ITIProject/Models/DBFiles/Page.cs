using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITIProject.Models.DBFiles
{
    public class Page
    {
        // ID.
        [Required]
        [Key]
        [Display(Name = "Page ID")]
        public int ID { get; set; }

        // Title.
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Page Title")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 char..")]
        public string Title { get; set; }
        // SubTitle.
        [DataType(DataType.Text)]
        [Display(Name = "Page SubTitle")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 char..")]
        public string SubTitle { get; set; }

        // SubTitle.
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Page Content")]
        public string Content { get; set; }
    }
}