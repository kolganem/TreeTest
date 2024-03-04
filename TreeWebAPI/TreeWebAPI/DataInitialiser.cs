using Microsoft.AspNetCore.Identity;
using TreeWebAPI.Models;

namespace TreeWebAPI;

public static class DataInitializer
{
    private static readonly string RootGuid = "4d62273e-f7b1-4b49-89fd-55b0c7965480";
    private static readonly string FirstNodeGuid = "79c12700-f08e-4737-b749-082f993b6e9a";
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
                
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new OperationCanceledException("Can't seed initial data to DB");
            }
        }

        return app;
    }
}