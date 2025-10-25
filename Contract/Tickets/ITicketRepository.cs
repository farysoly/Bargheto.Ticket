using Contract.Tickets.Commands;
using Contract.Tickets.Queries;
using Domain.Tickets.Entities;

namespace Contract.Tickets;

public interface ITicketRepository
{
    Task<Ticket> Execute(CreateTicketCommand command);
    Task Execute(UpdateTicketCommand command);
    Task Execute(DeleteTicketCommand command);

    Task<List<Ticket>> Execute(GetAllTicketQuery query);
    Task<List<Ticket>> Execute(GetAllTicketByStatusQuery query);
    Task<List<Ticket>> Execute(GetAllTicketForUserQuery query);
    Task<Ticket> Execute(GetTicketByIdQuery query);

}
