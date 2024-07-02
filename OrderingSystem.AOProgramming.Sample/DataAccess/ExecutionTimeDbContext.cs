using OrderingSystem.AOProgramming.Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderingSystem.AOProgramming.SampleData.Access;

public class ExecutionTimeDbContext: DbContext
{
    public ExecutionTimeDbContext(DbContextOptions<ExecutionTimeDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"Data Source=ExecutionTimeMonitor.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExecutionTimeMetadata>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MethodName).HasColumnType ("TEXT");
            entity.Property(e => e.DeclaringTime).HasColumnType("TEXT");
            entity.Property(e => e.ExecutionTime).HasColumnType("LONG");
        });
    }

    public DbSet<ExecutionTimeMetadata> ExecutionTimeMetadatas { get; set; }
}
