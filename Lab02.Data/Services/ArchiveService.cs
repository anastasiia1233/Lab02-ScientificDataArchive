using Lab02.Data.Data;
using Microsoft.EntityFrameworkCore;
using Lab02.Data.Entities;

namespace Lab02.Data.Services;

public class ArchiveService
{
    public void InitializeDatabase()
    {
        using var db = new AppDbContext();
        DbInitializer.Initialize(db);
    }
    public List<ProjectRow> GetProjects()
    {
        using var db = new AppDbContext();

        return db.ResearchProjects
            .Select(p => new ProjectRow
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                DatasetCount = p.Datasets.Count
            })
            .ToList();
    }
    public List<DatasetRow> GetPublicDatasets()
    {
        using var db = new AppDbContext();

        return db.Datasets
            .Where(d => d.IsPublic && (d.EmbargoUntil == null || d.EmbargoUntil <= DateTime.Now))
            .OrderByDescending(d => d.CreatedAt)
            .Select(d => new DatasetRow
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                ResearchProjectName = d.ResearchProject.Name,
                CreatedAt = d.CreatedAt,
                IsPublic = d.IsPublic,
                EmbargoUntil = d.EmbargoUntil,
                ResearchProjectId = d.ResearchProjectId
            })
            .ToList();
    }

    public List<DatasetRow> GetDatasets()
    {
        using var db = new AppDbContext();

        return db.Datasets
            .Select(d => new DatasetRow
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                ResearchProjectName = d.ResearchProject.Name,
                CreatedAt = d.CreatedAt,
                IsPublic = d.IsPublic,
                EmbargoUntil = d.EmbargoUntil,
                ResearchProjectId = d.ResearchProjectId,
            })
            .ToList();
    }

    public List<ResearcherRow> GetResearchers()
    {
        using var db = new AppDbContext();

        return db.Researchers
            .Select(r => new ResearcherRow
            {
                Id = r.Id,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Email = r.Email,
                ProjectCount = r.ProjectMembers.Count,
                UploadedVersionCount = r.UploadedVersions.Count
            })
            .ToList();
    }

    public void AddProject(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Введіть назву проєкту.");

        using var db = new AppDbContext();

        db.ResearchProjects.Add(new ResearchProject
        {
            Name = name,
            Description = description,
            CreatedAt = DateTime.Now
        });

        db.SaveChanges();
    }

    public void UpdateProject(int id, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Введіть назву проєкту.");

        using var db = new AppDbContext();
        var project = db.ResearchProjects.Find(id);

        if (project == null)
            throw new Exception("Проєкт не знайдено.");

        project.Name = name;
        project.Description = description;

        db.SaveChanges();
    }

    public void DeleteProject(int id)
    {
        using var db = new AppDbContext();
        var project = db.ResearchProjects.Find(id);

        if (project == null)
            throw new Exception("Проєкт не знайдено.");

        db.ResearchProjects.Remove(project);
        db.SaveChanges();
    }

    public void AddDataset(int projectId, string name, string description, bool isPublic, DateTime? embargoUntil)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Введіть назву набору даних.");

        using var db = new AppDbContext();

        if (db.ResearchProjects.Find(projectId) == null)
            throw new Exception("Проєкт не знайдено.");

        db.Datasets.Add(new Dataset
        {
            ResearchProjectId = projectId,
            Name = name,
            Description = description,
            CreatedAt = DateTime.Now,
            IsPublic = isPublic,
            EmbargoUntil = embargoUntil
        });

        db.SaveChanges();
    }

    public void UpdateDataset(int id, int projectId, string name, string description, bool isPublic, DateTime? embargoUntil)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Введіть назву набору даних.");

        using var db = new AppDbContext();
        var dataset = db.Datasets.Find(id);

        if (dataset == null)
            throw new Exception("Набір даних не знайдено.");

        if (db.ResearchProjects.Find(projectId) == null)
            throw new Exception("Проєкт не знайдено.");

        dataset.ResearchProjectId = projectId;
        dataset.Name = name;
        dataset.Description = description;
        dataset.IsPublic = isPublic;
        dataset.EmbargoUntil = embargoUntil;

        db.SaveChanges();
    }

    public void DeleteDataset(int id)
    {
        using var db = new AppDbContext();
        var dataset = db.Datasets.Find(id);

        if (dataset == null)
            throw new Exception("Набір даних не знайдено.");

        db.Datasets.Remove(dataset);
        db.SaveChanges();
    }

    public void AddResearcher(string firstName, string lastName, string email)
    {
        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email))
            throw new Exception("Заповніть усі поля дослідника.");

        using var db = new AppDbContext();

        if (db.Researchers.Any(r => r.Email == email))
            throw new Exception("Дослідник із такою електронною поштою вже існує.");

        db.Researchers.Add(new Researcher
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        });

        db.SaveChanges();
    }

    public void UpdateResearcher(int id, string firstName, string lastName, string email)
    {
        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email))
            throw new Exception("Заповніть усі поля дослідника.");

        using var db = new AppDbContext();
        var researcher = db.Researchers.Find(id);

        if (researcher == null)
            throw new Exception("Дослідника не знайдено.");

        if (db.Researchers.Any(r => r.Email == email && r.Id != id))
            throw new Exception("Ця електронна пошта вже використовується.");

        researcher.FirstName = firstName;
        researcher.LastName = lastName;
        researcher.Email = email;

        db.SaveChanges();
    }

    public void DeleteResearcher(int id)
    {
        using var db = new AppDbContext();
        var researcher = db.Researchers.Find(id);

        if (researcher == null)
            throw new Exception("Дослідника не знайдено.");

        db.Researchers.Remove(researcher);
        db.SaveChanges();
    }
    public void AddResearcherToProject(int projectId, int researcherId, string role, string accessLevel)
    {
        using var db = new AppDbContext();

        if (db.ResearchProjects.Find(projectId) == null)
            throw new Exception("Проєкт не знайдено.");

        if (db.Researchers.Find(researcherId) == null)
            throw new Exception("Дослідника не знайдено.");

        if (db.ProjectMembers.Any(pm => pm.ResearchProjectId == projectId && pm.ResearcherId == researcherId))
            throw new Exception("Цей дослідник уже доданий до проєкту.");

        db.ProjectMembers.Add(new ProjectMember
        {
            ResearchProjectId = projectId,
            ResearcherId = researcherId,
            Role = role,
            AccessLevel = accessLevel
        });

        db.SaveChanges();
    }

}

public class ProjectRow
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int DatasetCount { get; set; }
}

public class DatasetRow
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ResearchProjectName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsPublic { get; set; }
    public DateTime? EmbargoUntil { get; set; }
    public int ResearchProjectId { get; set; }
}

public class ResearcherRow
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int ProjectCount { get; set; }
    public int UploadedVersionCount { get; set; }
}
