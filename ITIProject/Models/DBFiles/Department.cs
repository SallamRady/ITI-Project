using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITIProject.Models.DBFiles
{
    public class Department
    {
        /// <summary>
        /// Properties in our class 'table'
        /// </summary>
        
        // ID.
        [Required]
        [Key]
        [Display(Name ="Department ID")]
        public int ID { get; set; }

        // Name.
        [Required]
        [Display(Name = "Department Name")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "The Name accept only characters.")]
        [StringLength(150,ErrorMessage = "Name length can't be more than 150 char..")]
        public string Name { get; set; }




        /************************** Start The Relations *******************************/

        /****************** Start Relation Department:Professor(Manger) *************/
        //Manager ID 'Professor_id' - Foregin Key
        //1-1 Department has one Manager
        [ForeignKey("Professor")]
        public int? Manager_ID { get; set; }
        public virtual Professor Professor { get; set; }
        /******************  End  Relation Department:Professor(Manger) *************/

        /****************** Start Relation Department:Professors *************/
        [Display(Name = "Department Professors")]
        [InverseProperty("Department")] // refer to department property in professor class.
        public virtual ICollection<Professor> Department_Professors { get; set; }
        /******************  End  Relation Department:Professors *************/

        /******************  Start  Relation Department:Students *************/
        [Display(Name = "Department Students")]
        [InverseProperty("Department")]
        public virtual ICollection<Student> Department_Students { get; set; }
        /******************   End   Relation Department:Students *************/

        /******************  Start  Relation Department:Courses *************/
        [Display(Name = "Department Students")]
        [InverseProperty("Department")]
        public virtual ICollection<Cource> Department_Courses { get; set; }
        /******************   End   Relation Department:Courses *************/

        /************************** End  The Relations *******************************/


    }
}