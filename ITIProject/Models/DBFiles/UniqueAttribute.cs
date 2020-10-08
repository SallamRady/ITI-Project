using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models.DBFiles
{
    internal class UniqueStudentEmailAttribute : ValidationAttribute
    {
        ApplicationDbContext db = new ApplicationDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email =Convert.ToString(value);
            if (BeUniqueUrl(email))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("This Email is already found");
            }
        }

        private bool BeUniqueUrl(string email)
        {
            return db.Students.FirstOrDefault(x => (x.Email == email)) == null ? true : false;
         }
    }
}