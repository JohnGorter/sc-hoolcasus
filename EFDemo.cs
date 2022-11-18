using Microsoft.EntityFrameworkCore;

public interface IStudentRepository {
    public List<Student> getAll();
    public Student? getStudentById(int id);
    public void addStudent(Student s);
    public void removeStudent(int id);

}

public class InMemoryStudentRepository : IStudentRepository
{
    List<Student> students = new List<Student>(); 
    public void addStudent(Student s)
    {
        students.Add(s);
    }

    public List<Student> getAll()
    {
       return students;
    }

    public Student? getStudentById(int id)
    {
       return students.Where(s => s.id == id).SingleOrDefault(); 
    }

    public void removeStudent(int id)
    {
        var s = getStudentById(id);
        if (s != null) students.Remove(s);
    }
}

// Deze klasse encapsuleert de database klasse en zorgt ervoor dat de buitenwereld kan praten tegen een
// persistentielaag zonder de details daarvan te kennen (Dependency Inversion). Immers de applicatie 
// kan entiteiten ophalen, aanpassen en verwijderen zonder te hoeven weten of het een database, een webapi
// of een andere persistentielaag is. Daarnaast hoeft de gebruiker geen kennis te hebben van EF of andere 
// implementatie details (saveChanges)
public class SqlLiteStudentRepository : IStudentRepository {
    private EFDemo database;
    public SqlLiteStudentRepository(){
        database = new EFDemo(); 
    }

    public void addStudent(Student s)
    {
        database.Students.Add(s); 
        database.SaveChanges(); 
    }

    public List<Student> getAll()
    {
        return database.Students.ToList(); 
    }

    public Student? getStudentById(int id)
    {
        return database.Students.Where(s => s.id == id).FirstOrDefault(); 
    }

    public void removeStudent(int id)
    {
        Student? s = getStudentById(id);
        if (s != null) {
           database.Students.Remove(s);
           database.SaveChanges(); 
        }
    }
}

// de DBContext klasse is de toegang tot je database. Deze klasse maakt de database structuur en geeft je methoden 
// om database queries en data manipulatie op de database te doen. De DbSet collecties kun je lezen als de tabellen
// die in deze database staan.

public class EFDemo : DbContext {
    public EFDemo()
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Filename=SchoolCasus.db");
    }
}

public class Student {
    public Student(String Name) { this.Name = Name; }
    public int id { get; set; } 
    public String Name { get; set; }
}

