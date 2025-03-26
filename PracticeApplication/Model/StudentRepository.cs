using System;
namespace PracticeApplication.Model
{
	public static class StudentRepository
	{
		
			public static List<Student> Students { get; set; } = new List<Student>(){
            new Student
            {
                Id = 1,
                StudenName ="Bhavna",
                Email = "student@gmail.com",
                Address = "Pune",
                Password = "Bhavna@123"

            },
            new Student
            {
                Id = 2,
                StudenName = "Debal",
                Email ="student2@gmail.com",
                Address = "Pune",
                Password = "Debal@123"

            }
            };
    
	}
}

