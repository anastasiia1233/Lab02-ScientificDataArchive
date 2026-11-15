namespace Lab02.Data.Entities;

public class ResearchProject
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<Dataset> Datasets { get; set; } = new List<Dataset>();
    public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
}