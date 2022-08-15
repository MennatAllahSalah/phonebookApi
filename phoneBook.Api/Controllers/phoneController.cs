using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phoneBook.Application.features.phoneBook.commands.creatPhone;
using phoneBook.Application.features.phoneBook.commands.deletePhone;
using phoneBook.Application.features.phoneBook.commands.updatePhone;
using phoneBook.Application.features.phoneBook.Queries.GetPhoneDetails;
using phoneBook.Application.features.phoneBook.Queries.GetPhoneList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace phoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class phoneController : ControllerBase
    {
        private readonly IMediator _mediator;

        public phoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllPosts")]
        public async Task<ActionResult<List<GetPhoneListViewModel>>> GetAllPosts()
        {
            var dtos = await _mediator.Send(new GetPhoneListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<ActionResult<GetPhoneDetailsViewModel>> GetPostById(int id)
        {
            var getEventDetailQuery = new GetPhoneDetailsQuery() { phoneId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<int>> Create([FromBody] creatPhoneCommand createPostCommand)
        {
            int id = await _mediator.Send(createPostCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdatePost")]
        public async Task<ActionResult> Update([FromBody] updatePhoneCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletePostCommand = new deletePhoneCommand() {id = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }
    }
}
