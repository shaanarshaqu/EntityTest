using EntityTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EntityTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudents _data;
        public StudentsController(IStudents data)
        {
            _data = data;
        }


        [HttpGet(Name ="listdata")]
        public IActionResult Get()
        {
            return Ok(_data.GetUsers());
        }


        [HttpPost("AddUser")]
        public IActionResult Post([FromBody] StudentsDTO student)
        {
            _data.AddUsers(student);
            return CreatedAtRoute("listdata", new { id = student.Id }, student);
        }


        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(int id, [FromBody] StudentsDTO user)
        {
            _data.UpdateUser(id, user);
            return Ok(id);
        }


    }
}
