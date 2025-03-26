using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using PracticeApplication.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeApplication.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class StudentController : ControllerBase
    {
      
        [HttpGet]
        [Route("All", Name ="GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]    // pre defined satatus code
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            //var students = new List<StudentDTO>();
            //foreach(var item in StudentRepository.Students)
            //{
            //    StudentDTO obj = new StudentDTO()
            //    {
            //        Id = item.Id,
            //        StudenName = item.StudenName,
            //        Address = item.Address,
            //        Email = item.Email
            //    };
            //    students.Add(obj);

            //}

            // Using LINQ Query 
            var students = StudentRepository.Students.Select(s => new StudentDTO()
            {

                Id = s.Id,
                StudenName = s.StudenName,
                Address = s.Address,
                Email = s.Email

            });




            // We are using Stuent Data so it is display the password. thats why we are not using the Student model . usinf studentDTO model.
            //List<Student> student = new List<Student>();

            //foreach (var item in StudentRepository.Students)
            //{

            //    student.Add(item);
            //


            //OK - 200 Success 
            return Ok(students);
        }

        //[HttpGet("{id:int}")]
        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]    // pre defined satatus code
        [ProducesResponseType(400, Type = typeof(Student))]
        [ProducesResponseType(404, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult GetStudentById(int id)
        {
            // BadRequest - 400 - Client Error 
            if (id <= 0)
                return BadRequest();

            var student  = StudentRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            // Not Found - 404 - Client Error 
            if (student == null)
                return NotFound($"Student with id {id} Not Found");

            var StudentDTO =  new StudentDTO()
            {

                Id = student.Id,
                StudenName = student.StudenName,
                Address = student.Address,
                Email = student.Email

            };

            //OK - 200 Success 
            return Ok(StudentDTO);
        }

        // [HttpGet("{name:string}", Name = "GetStudentBYName")]
        [HttpGet("{name}", Name = "GetStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]    // pre defined satatus code
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound) ]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<StudentDTO> GetStudentBYName(string name)
        {

            // BadRequest - 400 - Client Error 
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var student = StudentRepository.Students.Where(n => n.StudenName == name).FirstOrDefault();

            // Not Found - 404 - Client Error 
            if (student == null)
                return NotFound($"Student with name {name} Not Found");

            var StudentDTO = new StudentDTO()
            {

                Id = student.Id,
                StudenName = student.StudenName,
                Address = student.Address,
                Email = student.Email

            };

            return Ok(StudentDTO);
        }

        [HttpPost]
        [Route("Create",Name ="CreateStudent")]

        [ProducesResponseType(StatusCodes.Status200OK)]    // pre defined satatus code
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<StudentDTO> CreateStudent([FromBody]StudentDTO model)
        {
            //I am using ApiController so i dont want to use ModelState validation
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            //if (model.AdmissionDate < DateTime.Now)
            //{
            //    // 1. Directly adding error  msg to modelstate
            //    // 2. using custom attribute.

            //    ModelState.AddModelError("AdmissionDate Error", "Admission date must be greater than or equal to todays date");
            //    return BadRequest(ModelState);
            //}

            int newId = StudentRepository.Students.LastOrDefault().Id + 1;


            Student student = new Student
            {

                Id = newId,
                StudenName = model.StudenName,
                Address = model.Address,
                Email = model.Email

            };
            StudentRepository.Students.Add(student);
            
            model.Id = student.Id;

            // status - 201
            //https://localhost:7190/api/Student/1
            // Return new student details
            return CreatedAtRoute("GetStudentById", new { id = model.Id }, model);

           
        }


        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]    // pre defined satatus code
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<StudentDTO> UpdateStudent([FromBody] StudentDTO model)
        {

            if (model == null || model.Id < 0)
                BadRequest();

            var existingStudent = StudentRepository.Students.Where(s => s.Id == model.Id).FirstOrDefault();

            if (existingStudent == null)
                return NotFound();

            existingStudent.StudenName = model.StudenName;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;

            return NoContent();
        }



     


        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]    // pre defined satatus code
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<bool> DeleteStudent(int id)
        {

            // BadRequest - 400 - Client Error 
            if (id <= 0)
                return BadRequest();

            var student = StudentRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            // Not Found - 404 - Client Error 
            if (student == null)
                return NotFound($"Student with id {id} Not Found");

         
            StudentRepository.Students.Remove(student);

            return Ok(true);
        
        }


    }
}

