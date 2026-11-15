using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Data.Entities;

public class DatasetVersion
{
    public int Id { get; set; }
    public int DatasetId { get; set; }
    public int UploadedByResearcherId { get; set; }
    public string VersionNumber { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string Checksum { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; }
    public string ChangeDescription { get; set; } = string.Empty;
    public bool IsDownloadAllowed { get; set; }

    public Dataset Dataset { get; set; } = null!;
    public Researcher UploadedByResearcher { get; set; } = null!;
    public ICollection<MetadataItem> MetadataItems { get; set; } = new List<MetadataItem>();
}