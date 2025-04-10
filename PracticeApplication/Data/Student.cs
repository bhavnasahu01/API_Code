using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeApplication.Data
{
	public class Student
	{
        [Key] // Id as a primary key 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // using for automatic increment the id, auto genrated 

        public int Id { get; set; }

        public string StudenName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public DateTime DOB { get; set; }
    }
}

