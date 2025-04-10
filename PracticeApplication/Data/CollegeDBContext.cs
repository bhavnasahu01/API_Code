using System;
using Microsoft.EntityFrameworkCore;
using PracticeApplication.Data.Config;

namespace PracticeApplication.Data
{
	public class CollegeDBContext : DbContext
	{
		public CollegeDBContext(DbContextOptions<CollegeDBContext> options) : base(options)
		{

		}

		DbSet<Student> Students { get; set; }//It will take the as students table name.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



			// we created for seprated file 

			//modelBuilder.Entity<Student>().HasData(new List<Student>()
			//{ new Student
			//{
			//	Id = 1,
			//	StudenName ="Venkat",
			//	Address = "India",
			//	Email ="venkat@gmail.com",
			//             Password="Venkat@123",
			//	DOB = new DateTime(2022,12,12)
			//},

			//          new Student
			//         {
			//             Id = 2,
			//             StudenName ="Bhavna",
			//             Address = "India",
			//             Email ="bhavna@gmail.com",
			//              Password="Bhavna@123",
			//             DOB = new DateTime(2022,06,06)
			//         }
			// ,
			//           new Student
			//         {
			//             Id = 3,
			//             StudenName ="Debal",
			//             Address = "Kolkata",
			//             Email ="debal@gmail.com",
			//              Password="Debal@123",
			//             DOB = new DateTime(2021,10,10)
			//         }
			//         });


			// manage the Migrate tables with proper schema Datatype, size,
			//modelBuilder.Entity<Student>(entity =>
			//{
			//    entity.Property(n => n.StudenName).IsRequired();
			//    entity.Property(n => n.StudenName).HasMaxLength(250);
			//    entity.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
			//    entity.Property(n => n.Email).IsRequired().HasMaxLength(250);
			//    entity.Property(n => n.Password).IsRequired();
			//});



			// Table 1
			modelBuilder.ApplyConfiguration(new StudentConfig());
        }
    }
}

