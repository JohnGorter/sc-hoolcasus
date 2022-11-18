using System.Linq;
using Microsoft.EntityFrameworkCore;

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



public class SqliteCourseRepository : ICourseRepository
{
    CourseDbContext database = new CourseDbContext(); 

    public void addCourse(Course c)
    {
        database.Courses.Add(c);
        database.SaveChanges(); 
    }

    public Course? getCourseById(int id)
    {
        return database.Courses.Where(c => c.id == id).FirstOrDefault();
    }

    public List<Course> getCourses()
    {
        return database.Courses.ToList(); 
    }

    public void removeCourse(int id)
    {
        var c = getCourseById(id); 
        if (c != null) database.Courses.Remove(c); 
    }

    public void updateCourse(int id, Course changed){
        Course? orig = getCourseById(id); 
        if (orig != null) {
            database.Entry(orig).State = EntityState.Modified;
            database.Entry(orig).CurrentValues.SetValues(changed); 
            database.SaveChanges(); 
        }
    }

    public void addOutcome(Outcome o){
        database.Outcomes.Add(o); 
        database.SaveChanges(); 
    }

    public List<Goal> getGoals() {
        return database.Goals.ToList();
    }
    public List<Outcome> getOutcomes() {
        return database.Outcomes.ToList(); 
    }
}

