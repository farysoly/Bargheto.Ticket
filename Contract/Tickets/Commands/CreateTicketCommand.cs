using Domain.Tickets.Enums;

namespace Contract.Tickets.Commands;

public class CreateTicketCommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public PriorityType Priority { get; set; }
    public Guid UserId { get; private set; }

    public void SetUserId(Guid userId) => UserId = userId;
}
