using Microsoft.EntityFrameworkCore;

public class CourseDbContext : DbContext {

    
   public CourseDbContext() {
        Database.EnsureCreated(); 
   }
  
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseLazyLoadingProxies();
    optionsBuilder.UseSqlite("Filename=SchoolCasus.db");
   }
   public DbSet<Teacher> Teachers { get; set; }
   public DbSet<Lesson> Lessons { get; set; }
   public DbSet<Exam> Exams { get; set; }
   public DbSet<Outcome> Outcomes { get; set; }
   public DbSet<Course> Courses { get; set; }
   public DbSet<Goal> Goals { get; set; }
}

