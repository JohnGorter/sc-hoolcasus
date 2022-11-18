using Schoolcasus.Core;

namespace Schoolcasus.Data { 
    public interface ICourseRepository {
    public Course? getCourseById(int id);
    public List<Course> getCourses();

    public void addCourse(Course c);
    public void removeCourse(int id);  
    public void updateCourse(int id, Course changed);

    public void addOutcome(Outcome o);
    public List<Goal> getGoals(); 
    public List<Outcome> getOutcomes();

}
}