using Contract.Tickets;
using Contract.Tickets.Commands;
using Contract.Tickets.Queries;
using Domain.Tickets.Entities;
using Domain.Tickets.Enums;
using Infra.AppDbContexes;
using Microsoft.EntityFrameworkCore;

namespace Infra.Tickets;

public class TicketRepository(AppDbContext db) : ITicketRepository
{
    public async Task<Ticket> Execute(CreateTicketCommand command)
    {
        var ticket = Ticket.Create(command.Title, command.Description, command.Priority, command.UserId);
        db.Tickets.Add(ticket);
        db.SaveChanges();
        return ticket;
    }

    public async Task Execute(UpdateTicketCommand command)
    {
        var ticket = await db.Tickets.FirstOrDefaultAsync(x => x.Id == command.Id);
        if (ticket == null)
            throw new Exception($"Ticket with ID {command.Id} not found");

        ticket.Update(command.AssignedToUserId, (StatusType)command.Status, (PriorityType)command.Priority);
        db.SaveChanges();
    }

    public async Task Execute(DeleteTicketCommand command)
    {
        var ticket = await db.Tickets.FirstOrDefaultAsync(x => x.Id == command.Id);
        if (ticket == null)
            throw new Exception($"Ticket with ID {command.Id} not found");

        db.Remove(ticket);
        db.SaveChanges();
    }

    public async Task<List<Ticket>> Execute(GetAllTicketQuery query) 
        => await db.Tickets.ToListAsync();

    public async Task<List<Ticket>> Execute(GetAllTicketByStatusQuery query)
        => await db.Tickets.Where(x => x.Status == query.Status).ToListAsync();

    public async Task<List<Ticket>> Execute(GetAllTicketForUserQuery query) 
        => await db.Tickets.Where(x => x.CreatedByUserId == query.UserId).ToListAsync();

    public async Task<Ticket> Execute(GetTicketByIdQuery query)
        => await db.Tickets.FirstOrDefaultAsync(x => x.Id == query.Id);
}
