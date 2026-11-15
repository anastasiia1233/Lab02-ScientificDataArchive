using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Data.Entities;

public class ProjectMember
{
    public int Id { get; set; }
    public int ResearchProjectId { get; set; }
    public int ResearcherId { get; set; }
    public string Role { get; set; } = string.Empty;
    public string AccessLevel { get; set; } = string.Empty;

    public ResearchProject ResearchProject { get; set; } = null!;
    public Researcher Researcher { get; set; } = null!;
}