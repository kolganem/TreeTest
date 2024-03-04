using StoreProject.Infrastructure;
using TreeWebAPI.Models;

namespace TreeWebAPI.Infrastructure;

public interface ITreeNodeRepository : IGenericRepository<TreeNode>
{
    Task<TreeNode> GetByIdWithChildrenAsync(Guid id);
}