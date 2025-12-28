using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;

public class AppDbContext : DbContext
{
    public DbSet<TodoModel> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db;Cache=Shared");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoModel>(entity =>
        {
            entity.ToTable("Todo");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            entity.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(60);
            entity.Property(x => x.Done)
            .HasDefaultValue(false)
            .HasColumnType("Bool");
            entity.Property(x => x.CreatedAt)
            .HasColumnType("DateTime");

        });
    }
}