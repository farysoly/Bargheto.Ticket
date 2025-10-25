using Domain.Tickets.Enums;

namespace Contract.Tickets.Queries;

public class GetAllTicketByStatusQuery
{
    public StatusType Status { get; set; }
}
