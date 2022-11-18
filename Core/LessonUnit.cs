namespace Schoolcasus.Core { 
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
}