// // See https://aka.ms/new-console-template for more information


// // STAP 2. Voorbereiden van de data 
// using Schoolcasus.Core;
// using Schoolcasus.Domain;

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



using Schoolcasus.Domain;

var courseservice = new CourseService(); 
var OOSE = courseservice.getCourseByName("OOSE");
if (OOSE != null) {
    var result = courseservice.Validate(OOSE); 
    System.Console.WriteLine("Result " + result.result);
}

// if (c != null) {
//     c.Outcomes!.Add(outcome2); 
//     courserepo.updateCourse(1, c); 
// }
// var Outcomes = courserepo.getOutcomes(); 

// foreach (var outcome in Outcomes){
//     System.Console.WriteLine("Outcome " + outcome.Description + " " + outcome.id);
// }

// if (c != null) { 
//     var result = c.Validate(); 
//     System.Console.WriteLine("Result: " + result.result);
//     if (result.result == false) {
//         foreach(var rule in result.validationrules!) {
//             System.Console.WriteLine("Error: " + rule);
//         }
//     }
// }



// STAP 1. Overnemen van het klassediagram in code om te kijken hoe het "voelt" 
