using Microsoft.AspNetCore.Mvc;
using Schoolcasus.Core;
using Schoolcasus.Domain;
using Microsoft.AspNetCore.Cors;

namespace WebPresentation.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("MyPolicy")]
public class CourseController : ControllerBase {
    ICourseService courseservice = new CourseService(); 
    public List<Course> Get() {
        return courseservice.getAllCourses(); 
    }

    [HttpGet]
    [Route("validate/{id}")]
    public ValidationResult ValidateCourse(int id){
        var course = courseservice.getCourseById(id);
        if (course != null)
            return courseservice.Validate(course); 
        var result = new ValidationResult(); 
        result.result = false;
        result.validationrules = new List<String>(); 
        result.validationrules.Add("Unknown Course");
        return result;
    }
}
