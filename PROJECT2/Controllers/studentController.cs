using Microsoft.AspNetCore.Mvc;
using PROJECT2.model;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PROJECT2.model;
namespace PROJECT2.Controllers
{
    [Route("api/[[controler]]")]
    [ApiController]
    public class studentController : Controller
    {
        // adding new students data here 
        List<student> student_x = new List<student>() {
             new student() {id= 1, age=20, name="Mohan", Rollnumber=01, subject="math"},
             new student() {id= 2, age=30, name="Rohan", Rollnumber=02, subject="Eng"},
             new student() {id= 3, age=40, name="Lalit", Rollnumber=03, subject="Phy"},
             new student() {id= 4, age=50, name="Punit", Rollnumber=04, subject="Chem"},
             new student() {id= 5, age=50, name="Sumit", Rollnumber=08, subject="Bio"}
            };
        [HttpGet]
        // calling  the fun for data 
        public IActionResult Gets()
        {
            // checking the count if 0 then return no list found
            if (student_x.Count == 0) {
                return NotFound("No list found"); }
            // if not 0 then will return all the data 
            return Ok(student_x);
        }
        [HttpGet("GetStudent")]
        // for seaching the student 
        public IActionResult Get(int id)
        {
            var studenentnew = student_x.SingleOrDefault(x => x.id == id);
            if (studenentnew == null) { return NotFound("no students found"); }
            return Ok(studenentnew);
        }
        // to add the student  data in dp
        [HttpPost]
        public ActionResult Save(student studentnew)
        {
            student_x.Add(studentnew);
            if (student_x.Count == 0)
            {
                return NotFound("no student found");
            }
            return Ok(student_x);
        }
        // to delete the student data from the db 
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var studentnew = student_x.SingleOrDefault(x => x.id == id);
            if (studentnew == null) { return NotFound("student not found"); }
            student_x.Remove(studentnew);
            if (student_x.Count == 0)
            {
                return NotFound("no student found");
            }
            return Ok(student_x);
        }
    }
}
