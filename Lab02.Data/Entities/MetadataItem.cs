using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Data.Entities;

public class MetadataItem
{
    public int Id { get; set; }
    public int DatasetVersionId { get; set; }
    public string FieldName { get; set; } = string.Empty;
    public string FieldValue { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DatasetVersion DatasetVersion { get; set; } = null!;
}