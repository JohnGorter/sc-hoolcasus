
namespace Schoolcasus.Core { 
    public class Course {
    public int id { get; set; }
    public virtual Teacher? Teacher { get; set;}
    public String? Name { get; set; }
    public virtual ICollection<Outcome>? Outcomes { get; set; }
    public virtual ICollection<LessonUnit>? units { get; set; } 

    public ValidationResult Validate(){ 
        ValidationResult result = new ValidationResult(); 
        result.validationrules = new List<string>(); 
        result.result = true;

        List<Goal> courseGoals = new List<Goal>(); 
        if (Outcomes != null) foreach (Outcome outcome in Outcomes) { courseGoals.AddRange(outcome.getGoals()); }
        foreach(LessonUnit unit in units!){
           if(!unit.Validate(courseGoals)) { 
            // System.Console.WriteLine("LessonUnit " + unit.Description + "("+ unit.Code+") is serving a goal that is not for this course (" + unit.Goal!.Description + ")");
            result.validationrules.Add("LessonUnit " + unit.Description + "("+ unit.Code+") is serving a goal that is not for this course (" + unit.Goal!.Description + ")");
            result.result = false;
           // break;
           }
        }
        // DIT MOET NOG IN DE SD
        foreach (Goal goal in courseGoals) {
            Lesson? foundLesson = null;
            Exam? foundExam = null;
            foreach(LessonUnit unit in units!){
                if (unit.Goal == goal) {
                    if (unit is Lesson) foundLesson = unit as Lesson;
                    if (unit is Exam) foundExam = unit as Exam;
                }
            }
            if (foundExam == null || foundLesson == null) {
                if (foundLesson == null) {
                    // Console.WriteLine("There is a goal " + goal.Description + " that is not included in a lesson");
                    result.validationrules.Add("There is a goal " + goal.Description + " that is not included in a lesson");
                }
                if (foundExam == null) {
                    // Console.WriteLine("There is a goal " + goal.Description + " that is not included in an exam");
                    result.validationrules.Add("There is a goal " + goal.Description + " that is not included in an exam");
                }
                result.result = false;
               // break;
            }
        }
        // TOT HIER
        return result; 
    }
    public virtual ICollection<Goal> getGoals() { return new List<Goal>();}

}
}