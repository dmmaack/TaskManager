using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Maps;

namespace TaskManager.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
        public DbSet<ProjectEntity> Projects => Set<ProjectEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityMap());
            builder.ApplyConfiguration(new ProjectEntityMap());
            builder.ApplyConfiguration(new TaskEntityMap());
        }
    }
}