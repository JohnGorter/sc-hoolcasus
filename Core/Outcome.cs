namespace Schoolcasus.Core { 
    public class Outcome {
    public int id { get; set; }
    public String? Description { get; set; }
    public virtual ICollection<Goal>? Goals { get; set; }

    public virtual ICollection<Goal> getGoals() { return Goals!;}
}
}