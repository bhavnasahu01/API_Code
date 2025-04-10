using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PracticeApplication.Data.Config
{
	public class StudentConfig : IEntityTypeConfiguration<Student>
	{
		public StudentConfig()
		{
		}

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students"); // table name 
            builder.HasKey(x => x.Id); // primary key

            builder.Property(x => x.Id).UseIdentityColumn(); // using for automatic increment the id, auto genrated



            builder.Property(n => n.StudenName).IsRequired();
            builder.Property(n => n.StudenName).HasMaxLength(250);
            builder.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
            builder.Property(n => n.Email).IsRequired().HasMaxLength(250);
            builder.Property(n => n.Password).IsRequired();


            // add the data
            builder.HasData(new List<Student>()
            {
                 new Student
            {
                Id = 1,
                StudenName ="Venkat",
                Address = "India",
                Email ="venkat@gmail.com",
                Password="Venkat@123",
                DOB = new DateTime(2022,12,12)
            },

             new Student
            {
                Id = 2,
                StudenName ="Bhavna",
                Address = "India",
                Email ="bhavna@gmail.com",
                 Password="Bhavna@123",
                DOB = new DateTime(2022,06,06)
            }
             ,
              new Student
            {
                Id = 3,
                StudenName ="Debal",
                Address = "Kolkata",
                Email ="debal@gmail.com",
                 Password="Debal@123",
                DOB = new DateTime(2021,10,10)
            }

            });
           
        }
    }
}



