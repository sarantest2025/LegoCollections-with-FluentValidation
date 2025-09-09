using LegoCollections.Commands.LegoLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static LegoCollections.Queries.LegoLists.LegoListQuery;

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

    [HttpPost("Register")]
    public async Task<IActionResult> Create([FromBody] CreateLegoListCommand command)
    {
        var result = await _mediator.Send(command);
        if (result <= 0) return BadRequest("Failed to create Lego List");
        return Ok("Lego List Created Successfully");         
        //return CreatedAtAction(nameof(GetAll), new { id = result }, null);
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
