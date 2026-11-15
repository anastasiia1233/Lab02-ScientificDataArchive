using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Data.Entities;

public class Dataset
{
    public int Id { get; set; }
    public int ResearchProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsPublic { get; set; }
    public DateTime? EmbargoUntil { get; set; }

    public ResearchProject ResearchProject { get; set; } = null!;
    public ICollection<DatasetVersion> Versions { get; set; } = new List<DatasetVersion>();
}