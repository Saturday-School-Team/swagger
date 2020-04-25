
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController: ControllerBase
    {
        
        /// <summary>
        /// Get All Student
        /// </summary>
        /// <returns> List Of Student</returns>
        [HttpGet("Get")]
        public IActionResult GetStudent(){
            Student std = new Student{
                Name="Sagar",
                Email="asdkjah@kjhdsf.com"
            };
            return Ok(std);
        }

        /// <summary>
        /// Get Student with Phone Number
        /// </summary>
        /// <param name="pNum">Phone Number</param>
        /// <returns> Student with Phone Number</returns>
        [HttpGet("GetStudentWithPhone")]
        public Student GetSs(int pNum){
            Student std = new Student{
                Name="Sagars",
                Email="asdkjah@kjsahdsf.com",
                PhoneNumber = pNum
            };
            return std;
        }

        /// <summary>
        /// Create a Student
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Student/Add
        ///     {
        ///        "name": "Item1",
        ///        "Email": "mail@email.com",
        ///        "PhoneNumber": 12342345345
        ///     }
        ///
        /// </remarks>
        /// <param name="std">Student Info</param>
        /// <returns>A newly created Student</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public ActionResult<Student> Create(Student std)
        {
            std.Id = 1;
            return Ok(std);
        }

    }
}