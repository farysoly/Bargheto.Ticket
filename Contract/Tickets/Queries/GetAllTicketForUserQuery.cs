namespace Contract.Tickets.Queries;

public class GetAllTicketForUserQuery
{
    public Guid UserId { get; private set; }

    public void SetUserId(Guid userId)
        => UserId = userId;
}
