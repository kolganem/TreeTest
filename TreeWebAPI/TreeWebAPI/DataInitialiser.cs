using TreeWebAPI.Infrastructure.Exceptions;
using TreeWebAPI.Models;

namespace TreeWebAPI;

public static class DataInitializer
{
    private static readonly string RootGuid = "4d62273e-f7b1-4b49-89fd-55b0c7965480";
    private static readonly string FirstNodeGuid = "79c12700-f08e-4737-b749-082f993b6e9a";
    
    private static readonly string FirstErrorRecordId = "4b6d6393-36be-45c2-8d5a-b82d9f489244";
    private static readonly string SecondErrorRecordId = "db3f7227-7897-4fcb-9c87-2f0d4487c69e";
    private static readonly string ThirdErrorRecordId = "a6fad870-0e34-4404-b351-396f7744dd36";
    
    
    public static WebApplication Seed(this WebApplication app)
    {
        using (IServiceScope scope = app.Services.CreateScope())
        {
            using TreeDbContext context = scope.ServiceProvider.GetRequiredService<TreeDbContext>();

            try
            {
                context.Database.EnsureCreated();

                if (!context.TreeNode.Any())
                {
                    context.TreeNode.Add(
                        new TreeNode()
                        {
                            Id = new Guid(RootGuid),
                            Name = "first",
                            Parent = null,
                            Children = new List<TreeNode>
                            {
                                new()
                                {
                                    Id = new Guid(FirstNodeGuid), Name = "222", ParentId = new Guid(RootGuid), Children = 
                                        new List<TreeNode>()
                                        {
                                            new() {Id = new Guid(), Name = "555", ParentId = new Guid(FirstNodeGuid)}
                                        }
                                },
                                new() { Id = new Guid(), Name = "333", ParentId = new Guid(RootGuid)},
                                new() { Id = new Guid(), Name = "444", ParentId = new Guid(RootGuid)},
                            }
                        });
                }

                if (!context.ErrorRecords.Any())
                {
                    context.ErrorRecords.AddRange(new List<ErrorRecord>
                    {
                        new()
                        {
                            Id = new Guid(FirstErrorRecordId),
                            TypeInfo = nameof(Exception),
                            Time = new DateTime(2024, 01, 15).ToUniversalTime(),
                            Data = string.Empty
                        },
                        new()
                        {
                            Id = new Guid(SecondErrorRecordId),
                            TypeInfo = nameof(SecureException),
                            Time = new DateTime(2024, 01, 20).ToUniversalTime(),
                            Data = string.Empty
                        },
                        new()
                        {
                            Id = new Guid(ThirdErrorRecordId),
                            TypeInfo = nameof(Exception),
                            Time = new DateTime(2024, 01, 25).ToUniversalTime(),
                            Data = string.Empty
                        }
                    });
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new OperationCanceledException("Can't seed initial data to DB");
            }
        }

        return app;
    }
}