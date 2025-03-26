using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeApplication.Validators
{
	// this is custom validators
	public class DateCheckAttribute : ValidationAttribute
	{

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = (DateTime?)value;

            if(date < DateTime.Now)
            {
                return new ValidationResult("The date miust be greater than or equal to todays date");

            }

            return ValidationResult.Success;
        }

    }
}

