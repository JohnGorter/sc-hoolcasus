namespace Schoolcasus.Core { 
    public class Teacher : Person {
        public virtual ICollection<Course>? Courses { get; set; }
    }
}