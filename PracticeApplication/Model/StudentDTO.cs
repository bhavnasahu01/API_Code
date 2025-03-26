using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PracticeApplication.Validators;

namespace PracticeApplication.Model
{
	public class StudentDTO
	{

        // this attribute validate never validated 
        [ValidateNever]
        public int Id { get; set; }

        [Required(ErrorMessage ="Student Name is required")]
        [StringLength(30)]
        public string StudenName { get; set; }

        // Built in attribute validations 
        [EmailAddress(ErrorMessage ="Please enter valid email address")]
        public string Email { get; set; }

        //// Range validate
        //[Range(10,20)]
        //public string Age { get; set; }

        [Required]
        public string Address { get; set;}

        //// comapre the password 
        //[Compare(nameof(Password))]
        //public string Password { get; set; }

        //[DateCheck]
        //public DateTime AdmissionDate { get; set; }


    }
}

