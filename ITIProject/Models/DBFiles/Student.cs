﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITIProject.Models.DBFiles
{
    public class Student
    {
        /********************* Start  Properties *******************/
        // ID.
        [Required]
        [Key]
        [Display(Name = "User ID")]
        public int ID { get; set; }

        // Name.
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Student Name")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "The Name accept only characters.")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 char..")]
        public string Name { get; set; }

        // Email.
        [Required]
        [DataType(DataType.EmailAddress)]
        [UniqueStudentEmail]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // City.
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50 char..")]
        public string City { get; set; }


        // Level.
        [Required]
        [Range(1,4)]
        [Display(Name = "Level")]
        public int Level { get; set; }

        //Image..
        public string Image { get; set; }

        // Birth Year.
        [Required]
        [Display(Name = "Birth Year")]
        public int BirthYear { get; set; }

        [Required]
        [Display(Name = "Group")]
        public string Roles { get; set; } = "Students";
        /*********************  End  Properties *******************/


        /************************** Start The Relations *******************************/

        /****************** Start Relation Student:Department *************/
        [ForeignKey("Department")]
        public Nullable<int> Student_Department_ID { get; set; }
        public virtual Department Department { get; set; }
        /******************  End  Relation Professor:Department *************/

        /****************** Start Relation Student:Professor *************/
        [ForeignKey("Professor")]
        public Nullable<int> Student_Professor_supervisior_ID { get; set; }
        public virtual Professor Professor { get; set; }
        /******************  End  Relation Professor:Professor *************/


        /******************  Start Rlation Student:RegistrationOnCources **************/
        /// <summary>
        /// The student can register for more than one course
        /// </summary>
        [Display(Name = "Student register on Courses ")]
        [InverseProperty("Student")]
        public virtual ICollection<Students_Cources> Student_Cources { get; set; }
        /******************   End  Rlation Student:RegistrationOnCources  **************/



        /**************************  End  The Relations *******************************/

    }
}