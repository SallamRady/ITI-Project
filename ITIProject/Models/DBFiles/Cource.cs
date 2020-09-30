using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITIProject.Models.DBFiles
{
    public class Cource
    {
        /********************* Start  Properties *******************/
        // ID.
        [Required]
        [Key]
        [Display(Name = "Course ID")]
        public int ID { get; set; }

        // Name.
        [Required]
        [Display(Name = "Course Name")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "The Name accept only characters.")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 char..")]
        public string Name { get; set; }

        // Free.
        [Display(Name = "Course Free?")]
        public bool Free { get; set; } = false;


        // Cost.
        [Required]
        [Display(Name = "Course Cost")]
        public double Cost { get; set; }

        // Hours
        [Required]
        [Display(Name = "Course Hours")]
        [Range(1,100)]
        public int Hours { get; set; }

        // Degree
        [Required]
        [Display(Name = "Course Degree")]
        [Range(1, 150)]
        public int Degree { get; set; }

        // Min Degree
        [Required]
        [Display(Name = "Minumim Degree")]
        [Range(1, 150)]
        public int MinDegree { get; set; }
        /*********************  End  Properties *******************/


        /************************** Start The Relations *******************************/

        /******************  Start Rlation Cource:RegistrationOnCources **************/
        /// <summary>
        /// The course is subject to more than one registration process
        /// </summary>
        [Display(Name = "registration process for this Course")]
        [InverseProperty("Cource")]
        public virtual ICollection<Students_Cources> Cource_Students { get; set; }
        /******************   End  Rlation Student:RegistrationOnCources  **************/

        /****************** Start Relation Course:Department *************/
        [ForeignKey("Department")]
        public Nullable<int> Course_Department_ID { get; set; }
        public virtual Department Department { get; set; }
        /******************  End  Relation Course:Department *************/

        /****************** Start Relation Course:Professor *************/
        [ForeignKey("Professor")]
        public Nullable<int> Course_Professor_ID { get; set; }
        public virtual Professor Professor { get; set; }
        /******************  End  Relation Course:Professor *************/

        /**************************  End  The Relations *******************************/
    }
}