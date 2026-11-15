
using Lab02.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab02.Data.Data;

public class AppDbContext : DbContext
{
    public DbSet<ResearchProject> ResearchProjects { get; set; }
    public DbSet<Researcher> Researchers { get; set; }
    public DbSet<Dataset> Datasets { get; set; }
    public DbSet<ProjectMember> ProjectMembers { get; set; }
    public DbSet<DatasetVersion> DatasetVersions { get; set; }
    public DbSet<MetadataItem> MetadataItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=E:\\C#\\Lab02\\Lab02.Data\\ArchiveDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ResearchProject>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Entity<Researcher>()
         .HasIndex(r => r.Email)
         .IsUnique();

        modelBuilder.Entity<ResearchProject>()
            .HasMany(p => p.Datasets)
            .WithOne(d => d.ResearchProject)
            .HasForeignKey(d => d.ResearchProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ResearchProject>()
            .HasMany(p => p.ProjectMembers)
            .WithOne(pm => pm.ResearchProject)
            .HasForeignKey(pm => pm.ResearchProjectId);

        modelBuilder.Entity<Researcher>()
            .HasMany(r => r.ProjectMembers)
            .WithOne(pm => pm.Researcher)
            .HasForeignKey(pm => pm.ResearcherId);

        modelBuilder.Entity<Dataset>()
            .HasMany(d => d.Versions)
            .WithOne(v => v.Dataset)
            .HasForeignKey(v => v.DatasetId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Researcher>()
            .HasMany(r => r.UploadedVersions)
            .WithOne(v => v.UploadedByResearcher)
            .HasForeignKey(v => v.UploadedByResearcherId);

        modelBuilder.Entity<DatasetVersion>()
            .HasMany(v => v.MetadataItems)
            .WithOne(m => m.DatasetVersion)
            .HasForeignKey(m => m.DatasetVersionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DatasetVersion>()
        .HasIndex(v => new { v.DatasetId, v.VersionNumber })
        .IsUnique();
    }
}
