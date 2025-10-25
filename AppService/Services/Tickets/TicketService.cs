using AppService.Interfaces.Tickets;
using Contract.Tickets;
using Contract.Tickets.Commands;
using Contract.Tickets.Queries;
using Domain.Tickets.Entities;

namespace AppService.Services.Tickets;

public class TicketService(ITicketRepository ticketRepository) : ITicketService
{
    public async Task<Ticket> Execute(CreateTicketCommand command) => await ticketRepository.Execute(command);

    public async Task Execute(UpdateTicketCommand command) => await ticketRepository.Execute(command);

    public async Task Execute(DeleteTicketCommand command) => await ticketRepository.Execute(command);

    public async Task<List<Ticket>> Execute(GetAllTicketQuery query) => await ticketRepository.Execute(query);

    public async Task<List<Ticket>> Execute(GetAllTicketByStatusQuery query) => await ticketRepository.Execute(query);

    public async Task<List<Ticket>> Execute(GetAllTicketForUserQuery query) => await ticketRepository.Execute(query);

    public async Task<Ticket> Execute(GetTicketByIdQuery query) => await ticketRepository.Execute(query);
}
