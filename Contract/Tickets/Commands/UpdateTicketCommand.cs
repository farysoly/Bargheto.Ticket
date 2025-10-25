namespace Contract.Tickets.Commands;

public class UpdateTicketCommand
{
    public Guid Id { get; set; }
    public Guid? AssignedToUserId { get; set; }
    public byte Status { get; set; }
    public byte Priority { get; set; }
}
