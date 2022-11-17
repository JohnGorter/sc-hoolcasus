// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



class Person {
    public String Name { get; set; }
}

class Teacher : Person {
    public List<Course> Courses { get; set; }
}

class Course {
    public Teacher teacher { get; set;}
    public String Name { get; set; }
    public List<Outcome> Outcomes { get; set; }
    public List<Lesson> Lessons { get; set; } 
    public List<Exam> Exams { get; set; } 

    public bool Validate(){ return true;}
    public List<Goal> getGoals() { return new List<Goal>();}

}

class Goal {
    public String Description { get; set; }
}

class Outcome {
    public String Description { get; set; }
    public List<Goal> Goals { get; set; }

    public List<Goal> getGoals() { return new List<Goal>();}
}

class Lesson {
    public String Description { get; set; }
    public List<Goal> Goals { get; set; }

    public bool Validate() { return true; }
}

class Exam {
    public String Code { get; set; }
    public List<Goal> Goals { get; set; }

    public bool Validate() { return true; }
}
