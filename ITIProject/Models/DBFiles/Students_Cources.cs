using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITIProject.Models.DBFiles
{
    public class Students_Cources
    {
        // ID.
        [Required]
        [Key]
        [Display(Name = "Professor ID")]
        public int ID { get; set; }


        /************************** Start The Relations *******************************/

        /****************** Start Relation Student:RegistrationOnCources *************/
        [ForeignKey("Student")]
        public Nullable<int> Student_ID { get; set; }
        public virtual Student Student { get; set; }
        /******************  End  Relation Student:RegistrationOnCources *************/

        /****************** Start Relation Student:RegistrationOnCources *************/
        [ForeignKey("Cource")]
        public Nullable<int> Course_ID { get; set; }
        public virtual Cource Cource { get; set; }
        /******************  End  Relation Student:RegistrationOnCources *************/

        /************************** End The Relations *******************************/
    }
}