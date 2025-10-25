using Domain.Tickets.Enums;
using Domain.Users.Entities;

namespace Domain.Tickets.Entities;

public class Ticket
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public StatusType Status { get; private set; } = StatusType.OPEN;
    public PriorityType Priority { get; private set; } = PriorityType.LOW;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Guid CreatedByUserId { get; private set; }
    public Guid? AssignedToUserId { get; private set; }
    public User AssignedToUser { get; private set; }
    public User CreatedByUser { get; private set; }

    Ticket()
    {
    }

    Ticket(string title, string description, PriorityType priorityType, Guid userId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Priority = priorityType;
        CreatedAt = DateTime.Now;
        CreatedByUserId = userId;
    }

    public static Ticket Create(string title, string description, PriorityType priorityType, Guid userId)
        => new Ticket(title, description, priorityType, userId);

    public void Update(Guid? assignedToUserId, StatusType status, PriorityType priority)
    {
        UpdatedAt = DateTime.Now;
        AssignedToUserId = assignedToUserId;
        Status = status;
        Priority = priority;
    }
}
