using MediatR;
using LegoCollections.Commands.LegoFigures;
using Microsoft.AspNetCore.Mvc;
using LegoCollections.Queries.LegoFigures;

namespace LegoCollections.LegoCollections.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegoFiguresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LegoFiguresController(IMediator mediator) => _mediator = mediator;

        [HttpGet("list/{listId}")]
        public async Task<IActionResult> GetByList(int listId)
        {
            var result = await _mediator.Send(new GetFiguresInListQuery(listId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLegoFiguresCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetByList), new { listId = command.LegoListId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLegoFiguresCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLegoFigureCommand(id));
            return NoContent();
        }
    }
    
}