using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infra.Maps;

public class UserEntityMap : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {        
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("UserId")
            .UseIdentityColumn()
            .HasColumnType("BIGINT");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("VARCAHR(100)");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(180)
            .HasColumnType("VARCAHR(180)");

        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnType("VARCAHR(12)");

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnType("VARCAHR(12)");

        builder.Property(x => x.RegisterDate)
            .IsRequired()
            .HasColumnType("DATETIME");
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnType("BIT");

        builder.HasMany(x => x.Projects)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        


    }
}