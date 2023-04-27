namespace Sadin.Cms.Persistence.Outbox;

public sealed class OutboxMessage
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTimeOffset OccuredDate { get; set; }
    public DateTimeOffset? ProcessedDate { get; set; }
    public string? Error { get; set; }
}