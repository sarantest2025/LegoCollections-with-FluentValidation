using LegoCollections.LegoLists.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static LegoCollections.LegoLists.Queries.LegoListQuery;

namespace LegoCollections.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LegoListsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LegoListsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllListsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLegoListCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateLegoListCommand command)
    {
        if (id != command.Id) return BadRequest("Id mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLegoListCommand(id));
        return NoContent();
    }

}
