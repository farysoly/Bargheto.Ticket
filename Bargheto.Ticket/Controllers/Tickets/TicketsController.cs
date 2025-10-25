using AppService.Interfaces.Tickets;
using Contract.Tickets.Commands;
using Contract.Tickets.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EndPoint.Controllers.Tickets;

[ApiController]
[Route("api/[controller]")]
public class TicketsController(ITicketService ticketService) : ControllerBase
{
    private Guid CurrentUserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    //private string CurrentUserRole => User.FindFirstValue(ClaimTypes.Role);

    [Authorize(Roles = "EMPLOYEE")]
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateTicketCommand command)
    {
        if (command == null || string.IsNullOrEmpty(command.Title))
            return BadRequest(new { message = "Title is required." });

        command.SetUserId(CurrentUserId);

        await ticketService.Execute(command);
        return Ok();
    }

    [Authorize(Roles = "EMPLOYEE")]
    [HttpGet("my")]
    public async Task<IActionResult> GetAllTicketForUser([FromQuery] GetAllTicketForUserQuery query)
    {
        query.SetUserId(CurrentUserId);
        var tickets = await ticketService.Execute(query);
        return Ok(tickets);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllTickets([FromQuery] GetAllTicketQuery query)
    {
        var tickets = await ticketService.Execute(query);
        return Ok(tickets);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateTicketCommand command)
    {
        await ticketService.Execute(command);
        return Ok();
    }

    [Authorize(Roles = "ADMIN")]
    [HttpGet("GetAllByStatus")]
    public async Task<IActionResult> GetAllTicketByStatus([FromQuery] GetAllTicketByStatusQuery query)
    {
        var tickets = await ticketService.Execute(query);
        return Ok(tickets);
    }

    [Authorize]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetTicketById([FromQuery] GetTicketByIdQuery query)
    {
        var tickets = await ticketService.Execute(query);
        return Ok(tickets);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] DeleteTicketCommand command)
    {
        await ticketService.Execute(command);
        return Ok();
    }
}
