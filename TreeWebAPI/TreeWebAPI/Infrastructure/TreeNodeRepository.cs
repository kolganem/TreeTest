using Microsoft.EntityFrameworkCore;
using TreeWebAPI.Models;

namespace TreeWebAPI.Infrastructure;

public class TreeNodeRepository : GenericRepository<TreeNode>, ITreeNodeRepository
{
    private readonly TreeDbContext _context;

    public TreeNodeRepository(TreeDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<TreeNode> GetByIdWithChildrenAsync(Guid id)
    {
        return await _context.TreeNode
            .Include(t => t.Children)
            .SingleOrDefaultAsync(t => t.Id == id);
    }
}