
using Lab02.Data.Entities;

namespace Lab02.Data.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        if (context.ResearchProjects.Any())
            return;

        context.ResearchProjects.AddRange(
            new ResearchProject
            {
                Id = 1,
                Name = "Моніторинг якості води",
                Description = "Дослідження показників якості води у водоймах",
                CreatedAt = new DateTime(2026, 1, 10)
            },
            new ResearchProject
            {
                Id = 2,
                Name = "Кліматичні спостереження",
                Description = "Збір та аналіз кліматичних показників",
                CreatedAt = new DateTime(2026, 2, 15)
            });

        context.Researchers.AddRange(
            new Researcher { Id = 1, FirstName = "Олена", LastName = "Коваль", Email = "olena.koval@example.com" },
            new Researcher { Id = 2, FirstName = "Андрій", LastName = "Мельник", Email = "andrii.melnyk@example.com" },
            new Researcher { Id = 3, FirstName = "Ірина", LastName = "Шевченко", Email = "iryna.shevchenko@example.com" });

        context.ProjectMembers.AddRange(
            new ProjectMember { Id = 1, ResearchProjectId = 1, ResearcherId = 1, Role = "Керівник", AccessLevel = "Approve" },
            new ProjectMember { Id = 2, ResearchProjectId = 1, ResearcherId = 2, Role = "Дослідник", AccessLevel = "Upload" },
            new ProjectMember { Id = 3, ResearchProjectId = 2, ResearcherId = 2, Role = "Дослідник", AccessLevel = "Read" },
            new ProjectMember { Id = 4, ResearchProjectId = 2, ResearcherId = 3, Role = "Керівник", AccessLevel = "Approve" });

        context.Datasets.AddRange(
            new Dataset
            {
                Id = 1,
                ResearchProjectId = 1,
                Name = "Показники води за 2026 рік",
                Description = "Результати лабораторних вимірювань",
                CreatedAt = new DateTime(2026, 3, 1),
                IsPublic = true
            },
            new Dataset
            {
                Id = 2,
                ResearchProjectId = 1,
                Name = "Хімічний склад води",
                Description = "Дані про хімічні елементи у зразках",
                CreatedAt = new DateTime(2026, 3, 10),
                IsPublic = false
            },
            new Dataset
            {
                Id = 3,
                ResearchProjectId = 2,
                Name = "Температурні спостереження",
                Description = "Щоденні показники температури повітря",
                CreatedAt = new DateTime(2026, 4, 1),
                IsPublic = true
            });

        context.DatasetVersions.AddRange(
            new DatasetVersion
            {
                Id = 1,
                DatasetId = 1,
                UploadedByResearcherId = 1,
                VersionNumber = "1.0",
                FileName = "water_data.csv",
                FilePath = "Files/water_data.csv",
                Checksum = "abc123",
                UploadedAt = new DateTime(2026, 3, 2),
                ChangeDescription = "Перше завантаження даних",
                IsDownloadAllowed = true
            },
            new DatasetVersion
            {
                Id = 2,
                DatasetId = 1,
                UploadedByResearcherId = 2,
                VersionNumber = "2.0",
                FileName = "water_data_v2.csv",
                FilePath = "Files/water_data_v2.csv",
                Checksum = "def456",
                UploadedAt = new DateTime(2026, 3, 15),
                ChangeDescription = "Оновлено результати вимірювань",
                IsDownloadAllowed = false
            },
            new DatasetVersion
            {
                Id = 3,
                DatasetId = 2,
                UploadedByResearcherId = 1,
                VersionNumber = "1.0",
                FileName = "chemical_data.csv",
                FilePath = "Files/chemical_data.csv",
                Checksum = "ghi789",
                UploadedAt = new DateTime(2026, 3, 12),
                ChangeDescription = "Перше завантаження хімічних показників",
                IsDownloadAllowed = true
            },
            new DatasetVersion
            {
                Id = 4,
                DatasetId = 3,
                UploadedByResearcherId = 3,
                VersionNumber = "1.0",
                FileName = "temperature.csv",
                FilePath = "Files/temperature.csv",
                Checksum = "jkl012",
                UploadedAt = new DateTime(2026, 4, 2),
                ChangeDescription = "Початкові температурні спостереження",
                IsDownloadAllowed = true
            });

        context.MetadataItems.AddRange(
            new MetadataItem { Id = 1, DatasetVersionId = 1, FieldName = "Temperature", FieldValue = "18.5", Unit = "°C", Description = "Температура води" },
            new MetadataItem { Id = 2, DatasetVersionId = 1, FieldName = "pH", FieldValue = "7.2", Unit = "pH", Description = "Рівень кислотності" },
            new MetadataItem { Id = 3, DatasetVersionId = 2, FieldName = "Temperature", FieldValue = "19.1", Unit = "°C", Description = "Оновлена температура води" },
            new MetadataItem { Id = 4, DatasetVersionId = 2, FieldName = "pH", FieldValue = "7.4", Unit = "pH", Description = "Оновлений рівень кислотності" },
            new MetadataItem { Id = 5, DatasetVersionId = 3, FieldName = "Oxygen", FieldValue = "8.1", Unit = "mg/L", Description = "Вміст розчиненого кисню" },
            new MetadataItem { Id = 6, DatasetVersionId = 4, FieldName = "Temperature", FieldValue = "16.8", Unit = "°C", Description = "Температура повітря" });

        context.SaveChanges();
    }
}
