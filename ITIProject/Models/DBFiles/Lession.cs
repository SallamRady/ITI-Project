using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITIProject.Models.DBFiles
{
    public class Lession
    {
        // ID.
        [Required]
        [Key]
        [Display(Name = "Lession ID")]
        public int ID { get; set; }

        // Title.
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Lession Title")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 char..")]
        public string Title { get; set; }
        // SubTitle.
        [DataType(DataType.Text)]
        [Display(Name = "Lession SubTitle")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 char..")]
        public string SubTitle { get; set; }

        // SubTitle.
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Lession Content")]
        public string Content { get; set; }

        //1-1 Lession belong to one course
        [Display(Name = "Course")]
        [ForeignKey("Cource")]
        public Nullable<int> course_id { get; set; }
        public virtual Cource Cource { get; set; }
    }
}