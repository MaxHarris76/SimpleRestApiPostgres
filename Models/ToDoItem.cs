namespace SimpleRestApiPostgres.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
    }
}