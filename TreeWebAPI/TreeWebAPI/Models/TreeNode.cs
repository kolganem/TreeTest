using System.ComponentModel.DataAnnotations;

namespace TreeWebAPI.Models;

public class TreeNode
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public Guid? ParentId { get; set; }

    public TreeNode Parent { get; set; }

    public ICollection<TreeNode>? Children { get; set; }
}