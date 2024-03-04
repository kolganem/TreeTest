using Microsoft.AspNetCore.Mvc;
using TreeWebAPI.Infrastructure.Helper;
using TreeWebAPI.Models;
using TreeWebAPI.Services;

namespace TreeWebAPI.Controllers
{
    [Route("api/tree/")]
    [ApiController]
    public class TreeNodeController : ControllerBase
    {
        private readonly ITreeNodeService _treeNodeService;

        public TreeNodeController(ITreeNodeService treeNodeService)
        {
            _treeNodeService = treeNodeService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            TreeNode node = await _treeNodeService.GetByIdWithChildrenAsync(id);
            
            return Ok(JsonHelper.ToJsonIgnoreLoopHandling(node));
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<bool>> Create(Guid parentId, string nodeName)
        {
            return await _treeNodeService.CreateAsync(parentId, nodeName);
        }
        
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<bool>> Update(Guid id, string newNodeName)
        {
            return await _treeNodeService.UpdateTreeNameAsync(id, newNodeName);
        }
       

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(await _treeNodeService.DeleteProductAsync(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
