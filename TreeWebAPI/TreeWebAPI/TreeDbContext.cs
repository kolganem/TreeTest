using System.Configuration;
using Microsoft.EntityFrameworkCore;
using TreeWebAPI.Models;

namespace TreeWebAPI;

public class TreeDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public TreeDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string? connectionString = _configuration.GetConnectionString("WebApiDatabase");
        options.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TreeNode>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x=> x.Name);
            entity.HasOne(x=> x.Parent)
                .WithMany(x=> x.Children)
                .HasForeignKey(x=> x.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        builder.Entity<ErrorRecord>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x=> x.TypeInfo)
                .IsRequired();
            entity.Property(x=> x.Data)
                .IsRequired();
            
        });
    }

    public DbSet<TreeNode> TreeNode { get; set; }
    
    public DbSet<ErrorRecord> ErrorRecords { get; set; }
    
    
    
    
}