// See https://aka.ms/new-console-template for more information
Goal goal = new Goal() { Description = "PROGRAMMEREN"};
Goal goal2 = new Goal() { Description = "REFLECTEREN"};
Goal goal3 = new Goal() { Description = "PRESENTEREN"};
Goal goal4 = new Goal() { Description = "NIETRELEVANT"};

Outcome outcome = new Outcome() { Goals = new List<Goal>(), Description = "PROFESSIONAL DEVELOPER "};
outcome.Goals.Add(goal); 
outcome.Goals.Add(goal2); 
outcome.Goals.Add(goal3); 

Lesson lesson = new Lesson() { Description="Develop a game", Goals= new List<Goal>() } ;
lesson.Goals.Add(goal); 
Lesson lesson2 = new Lesson() { Description="Presenteren", Goals = new List<Goal>() };
lesson.Goals.Add(goal3); 
Lesson lesson3 = new Lesson() { Description="Onzinles", Goals = new List<Goal>() };
lesson.Goals.Add(goal4); 

Exam e = new Exam() { Goals = new List<Goal>(), Code = "SToets1" };
e.Goals.Add(goal); 

Teacher teacher = new Teacher() { Name = "John "};
Course course = new Course() { Name="OOSE", Teacher = teacher, Outcomes = new List<Outcome>(), Lessons = new List<Lesson>(), Exams = new List<Exam>()};
course.Lessons.AddRange(new List<Lesson>() { lesson, lesson2, lesson3});
course.Exams.AddRange(new List<Exam>() { e });


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

    public bool Validate(){ return true;}
    public List<Goal> getGoals() { return new List<Goal>();}

}

class Goal {
    public String? Description { get; set; }
}

class Outcome {
    public String? Description { get; set; }
    public List<Goal>? Goals { get; set; }

    public List<Goal>? getGoals() { return new List<Goal>();}
}

class Lesson {
    public String? Description { get; set; }
    public List<Goal>? Goals { get; set; }

    public bool Validate() { return true; }
}

class Exam {
    public String? Code { get; set; }
    public List<Goal>? Goals { get; set; }

    public bool Validate() { return true; }
}
