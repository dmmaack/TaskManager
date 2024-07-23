using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infra.Maps;

public class TaskEntityMap : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Tasks");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("TaskIdId")
            .UseIdentityColumn()
            .HasColumnType("BIGINT");

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("VARCAHR(150)");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(5000)
            .HasColumnType("VARCAHR(5000)");

        builder.Property(x => x.StartDate)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder.Property(x => x.EndDate)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder.Property(x => x.RegisterDate)
            .IsRequired()
            .HasColumnType("DATETIME");
        
        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnType("INT");
        
        builder.Property(x => x.ProjectId)
            .HasColumnType("BIGINT");

    }
}