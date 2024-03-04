using StoreProject.Infrastructure;
using TreeWebAPI.Infrastructure.Exceptions;
using TreeWebAPI.Models;

namespace TreeWebAPI.Services;

public class TreeNodeService : ITreeNodeService
{
    private readonly IUnitOfWork _unitOfWork;

    public TreeNodeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TreeNode> GetByIdAsync(Guid id)
    {
        return await _unitOfWork.TreeNodes.GetById(id);
    }

    public async Task<TreeNode> GetByIdWithChildrenAsync(Guid id)
    {
        return await _unitOfWork.TreeNodes.GetByIdWithChildrenAsync(id);
    }

    public async Task<bool> CreateAsync(Guid parentNodeId, string nodeName)
    {
        TreeNode node = await _unitOfWork.TreeNodes.GetById(parentNodeId);

        if (node is not null)
        {
            TreeNode newNode = new()
            {
                Id = new Guid(),
                Name = nodeName,
                ParentId = parentNodeId
            };

            await _unitOfWork.TreeNodes.Add(newNode);
        }
        else
        {
            throw new SecureException("Can't find parent node for new creating new node");
        }

        return await _unitOfWork.SaveAsync() > 0;
    }

    public async Task<bool> UpdateTreeNameAsync(Guid id, string newName)
    {
        TreeNode node = await _unitOfWork.TreeNodes.GetById(id);
        if (node is not null)
        {
           node.Name = newName;
        }
        
        return await _unitOfWork.SaveAsync() > 0;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        TreeNode node = await _unitOfWork.TreeNodes.GetById(id);
        if (node is not null)
        {
            _unitOfWork.TreeNodes.Delete(node);
        }
        
        return await _unitOfWork.SaveAsync() > 0;
    }
}
