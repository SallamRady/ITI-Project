using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ITIProject.Models.DBFiles
{
    internal class UniqueProfessorEmailAttribute : ValidationAttribute
    {
        ApplicationDbContext db = new ApplicationDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = Convert.ToString(value);
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
            return db.Professors.FirstOrDefault(x => (x.Email == email)) == null ? true : false;
        }
    }
}