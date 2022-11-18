// // See https://aka.ms/new-console-template for more information


// // STAP 2. Voorbereiden van de data 
// Goal goal = new Goal() { Description = "PROGRAMM"};
// Goal goal2 = new Goal() { Description = "REFLECT"};
// Goal goal3 = new Goal() { Description = "PRESENT"};
// Goal goal4 = new Goal() { Description = "IRRELEVANT"};

// Outcome outcome = new Outcome() { Goals = new List<Goal>(), Description = "PROFESSIONAL DEVELOPER "};
// outcome.Goals.Add(goal); 
// outcome.Goals.Add(goal2); 
// outcome.Goals.Add(goal3); 

// Outcome outcome2 = new Outcome() { Goals = new List<Goal>(), Description = "NONSENS QUALIFICATION"};
// outcome2.Goals.Add(goal4); 

// Lesson lesson = new Lesson("", "Develop a game") { Goal = goal};
// Lesson lesson2 = new Lesson("", "Write learning journals") { Goal = goal2};
// Lesson lesson3 = new Lesson("", "Knowledge sharing lesson") { Goal = goal3};
// Lesson lesson4 = new Lesson("", "Bullshitlesson") { Goal = goal4};

// Exam e = new Exam("SExam1", "") { Goal = goal };
// Exam e2 = new Exam("SExam2", "") { Goal = goal2 };
// Exam e3 = new Exam("SExam3", "") { Goal = goal3 };

// Teacher teacher = new Teacher() { Name = "John "};
// Course course = new Course() { Name="OOSE", Teacher = teacher, Outcomes = new List<Outcome>(), units = new List<LessonUnit>() } ;
// course.Outcomes.Add(outcome);
// course.units.Add(lesson); 
// course.units.Add(lesson2); 
// course.units.Add(lesson3); 
// course.units.Add(e); 
// course.units.Add(e2); 
// course.units.Add(e3); 

// // STAP 3. Sequence diagram overnemen en 
// var result = course.Validate();
// Console.WriteLine($"Is the course consistent? {result.result}"); 
// if (result.result == false) {
//     foreach (String line in result.validationrules!)
//         Console.WriteLine($"{line}"); 
// }


var courserepo = new SqliteCourseRepository(); 
var c = courserepo.getCourseById(1); 
// if (c != null) {
//     c.Outcomes!.Add(outcome2); 
//     courserepo.updateCourse(1, c); 
// }
// var Outcomes = courserepo.getOutcomes(); 

// foreach (var outcome in Outcomes){
//     System.Console.WriteLine("Outcome " + outcome.Description + " " + outcome.id);
// }

if (c != null) { 
    var result = c.Validate(); 
    System.Console.WriteLine("Result: " + result.result);
    if (result.result == false) {
        foreach(var rule in result.validationrules!) {
            System.Console.WriteLine("Error: " + rule);
        }
    }
}



// STAP 1. Overnemen van het klassediagram in code om te kijken hoe het "voelt" 
public class Person {
    public int id { get; set; }
    public String? Name { get; set; }
}

public class Teacher : Person {
    public virtual ICollection<Course>? Courses { get; set; }
}

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

public class Goal {
    public int id { get; set; }
    public String? Description { get; set; }
}

public class Outcome {
    public int id { get; set; }
    public String? Description { get; set; }
    public virtual ICollection<Goal>? Goals { get; set; }

    public virtual ICollection<Goal> getGoals() { return Goals!;}
}

public abstract class LessonUnit {
    public LessonUnit(String Code, String Description)
    {
        this.Code = Code;
        this.Description = Description; 
    }
    public int id { get; set; }
    public String Code { get; set; }
    public String Description { get; set; }

    public virtual Goal? Goal { get; set; }

    public bool Validate(List<Goal> courseGoals) { 
        return (courseGoals.IndexOf(Goal!) >= 0); // op dit moment kijken we echt naar object identiteit, niet naar code of titel van een goal..
     }
}
public class Lesson : LessonUnit {
    public Lesson(String Code, String Description) : base(Code, Description) {}
}

public class Exam : LessonUnit {
    public Exam(String Code, String Description) : base(Code, Description) {}
}

public class ValidationResult {
    public bool result { get; set; }
    public List<String>? validationrules { get; set;}
}
