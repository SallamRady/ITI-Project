using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITIProject.Models.DBFiles
{
    public class Professor
    {
        // ID.
        [Required]
        [Key]
        [Display(Name = "Professor ID")]
        public int ID { get; set;}

        // Name.
        [Required]
        [Display(Name = "Professor Name")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "The Name accept only characters.")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 char..")]
        public string Name { get; set; }

        // City.
        [Required]
        [Display(Name = "Professor City")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50 char..")]
        public string City { get; set; }


        // Salary.
        [Required]
        [Display(Name = "Professor Salary")]
        public double Salary { get; set; }


        /************************** Start The Relations *******************************/

        /****************** Start Relation Professor:Department *************/
        [ForeignKey("Department")]
        public Nullable<int> Professor_Department_ID { get; set; }
        public virtual Department Department { get; set; }
        /******************  End  Relation Professor:Department *************/

        /******************  Start Rlation Professor:Students **************/
        /// <summary>
        /// One professor supervises more than one student
        /// </summary>
        [Display(Name = "Students Under professor supervion")]
        [InverseProperty("Professor")]
        public virtual ICollection<Student> Student_Under_Prof { get; set; }
        /******************   End  Rlation Professor:Students **************/

        /******************  Start Rlation Professor:Courses **************/
        /// <summary>
        /// One professor supervises more than one student
        /// </summary>
        [Display(Name = "Courses professor teach")]
        [InverseProperty("Professor")]
        public virtual ICollection<Cource> Courses_prof_teach { get; set; }
        /******************   End  Rlation Professor:Courses **************/


        /**************************  End  The Relations *******************************/
    }
}