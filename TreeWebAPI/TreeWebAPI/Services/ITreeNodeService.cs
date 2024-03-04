using TreeWebAPI.Models;

namespace TreeWebAPI.Services;

public interface ITreeNodeService
{
    
    Task<TreeNode> GetByIdAsync(Guid id);

    Task<TreeNode> GetByIdWithChildrenAsync(Guid id);
    
    Task<bool> CreateAsync(Guid nodeId, string nodeName);

    Task<bool> UpdateTreeNameAsync(Guid id, string newName);

    Task<bool> DeleteProductAsync(Guid id);
    
}