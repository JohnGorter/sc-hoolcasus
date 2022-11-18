using Schoolcasus.Core;
using Schoolcasus.Data;

namespace Schoolcasus.Domain { 
    public class CourseService: ICourseService {

        ICourseRepository repository;

        public CourseService() : this(new SqliteCourseRepository()) {}

        public CourseService(ICourseRepository repo)
        {
            repository = repo;
        }
        public ValidationResult Validate(Course c) {
            return c.Validate(); 
        }
        public List<Course> getAllCourses() {
           return repository.getCourses(); 
        }
        public void addCourse(Course c){
            repository.addCourse(c); 
        }

        public Course? getCourseById(int id){
            return repository.getCourseById(id);
        }
        public Course? getCourseByName(String name){
            var courses = repository.getCourses(); 
            foreach (var course in courses){
                if (course.Name!.Equals(name)) return course;
            }
            return null;
        }

    }
}