using Schoolcasus.Core;

namespace Schoolcasus.Domain { 
    public interface ICourseService {
        public ValidationResult Validate(Course c);
        public List<Course> getAllCourses();
        public void addCourse(Course c);

        public Course? getCourseById(int id);
        public Course? getCourseByName(String name);
    }
 }