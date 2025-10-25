using Domain.Tickets.Enums;
using Domain.Users.Entities;

namespace Domain.Tickets.Entities;

public class Ticket
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public StatusType Status { get; set; } = StatusType.OPEN;
    public PriorityType Priority { get; set; } = PriorityType.LOW;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid? AssignedToUserId { get; set; }
    public User AssignedToUser { get; set; }
    public User CreatedByUser { get; set; }

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
