// See https://aka.ms/new-console-template for more information


// STAP 2. Voorbereiden van de data 
Goal goal = new Goal() { Description = "PROGRAMM"};
Goal goal2 = new Goal() { Description = "REFLECT"};
Goal goal3 = new Goal() { Description = "PRESENT"};
Goal goal4 = new Goal() { Description = "IRRELEVANT"};

Outcome outcome = new Outcome() { Goals = new List<Goal>(), Description = "PROFESSIONAL DEVELOPER "};
outcome.Goals.Add(goal); 
outcome.Goals.Add(goal2); 
outcome.Goals.Add(goal3); 

Outcome outcome2 = new Outcome() { Goals = new List<Goal>(), Description = "NONSENS QUALIFICATION"};
outcome2.Goals.Add(goal4); 

Lesson lesson = new Lesson() { Description="Develop a game", Goal = goal} ;
Lesson lesson2 = new Lesson() { Description="Present a lesson", Goal = goal3};
Lesson lesson3 = new Lesson() { Description="Bullshitlesson", Goal = goal4};

Exam e = new Exam() {Code = "SExam1", Goal = goal };

Teacher teacher = new Teacher() { Name = "John "};
Course course = new Course() { Name="OOSE", Teacher = teacher, Outcomes = new List<Outcome>(), Lessons = new List<Lesson>(), Exams = new List<Exam>()};
course.Outcomes.AddRange(new List<Outcome>{ outcome });
course.Lessons.AddRange(new List<Lesson>() { lesson, lesson2});
course.Exams.AddRange(new List<Exam>() { e });

// STAP 3. Sequence diagram overnemen en testen
Console.WriteLine($"Is the course consistent? {course.Validate()}"); 


// STAP 1. Overnemen van het klassediagram in code om te kijken hoe het "voelt" 
class Person {
    public String? Name { get; set; }
}

class Teacher : Person {
    public List<Course>? Courses { get; set; }
}

class Course {
    public Teacher? Teacher { get; set;}
    public String? Name { get; set; }
    public List<Outcome>? Outcomes { get; set; }
    public List<Lesson>? Lessons { get; set; } 
    public List<Exam>? Exams { get; set; } 

    public bool Validate(){ 
        bool valid = true; 
        List<Goal> courseGoals = new List<Goal>(); 
        if (Outcomes != null) foreach (Outcome outcome in Outcomes) { courseGoals.AddRange(outcome.getGoals()); }
        foreach(Lesson lesson in Lessons!){
           if(!lesson.Validate(courseGoals)) { 
            System.Console.WriteLine("Lesson " + lesson.Description + " is serving a goal that is not for this course (" + lesson.Goal!.Description + ")");
            valid = false;
            break;
           }
        }
        if (valid) {
            foreach(Exam exam in Exams!){
                if(!exam.Validate(courseGoals)) { 
                    System.Console.WriteLine("Exam " + exam.Code + " is serving a goal that is not for this course (" + exam.Goal!.Description + ")");
                    valid = false;
                    break;
                }
            }
        }
        return valid; 
    }
    public List<Goal> getGoals() { return new List<Goal>();}

}

class Goal {
    public String? Description { get; set; }
}

class Outcome {
    public String? Description { get; set; }
    public List<Goal>? Goals { get; set; }

    public List<Goal> getGoals() { return Goals!;}
}

class Lesson {
    public String? Description { get; set; }
    public Goal? Goal { get; set; }

    public bool Validate(List<Goal> courseGoals) { 
        return (courseGoals.IndexOf(Goal!) >= 0); // op dit moment kijken we echt naar object identiteit, niet naar code of titel van een goal..
     }
}

class Exam {
    public String? Code { get; set; }
    public Goal? Goal { get; set; }

    public bool Validate(List<Goal> courseGoals) { 
        return (courseGoals.IndexOf(Goal!) >= 0); // op dit moment kijken we echt naar object identiteit, niet naar code of titel van een goal..
    }
}
