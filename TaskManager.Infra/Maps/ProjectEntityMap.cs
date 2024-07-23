using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infra.Maps;

public class ProjectEntityMap : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("ProjectId")
            .UseIdentityColumn()
            .HasColumnType("BIGINT");

        builder.Property(x => x.ProjectName)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("VARCAHR(150)");

        builder.Property(x => x.RegisterDate)
            .IsRequired()
            .HasColumnType("DATETIME");
            
        builder.Property(x => x.StartDate)
            .IsRequired()
            .HasColumnType("DATETIME");
        
        builder.Property(x => x.EndDate)
            .IsRequired()
            .HasColumnType("DATETIME");
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnType("BIT");
        
        builder.Property(x => x.UserId)
            .HasColumnType("BIGINT");

        builder.HasMany(x => x.Tasks)
            .WithOne(x => x.Project)
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}