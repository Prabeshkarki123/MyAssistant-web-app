namespace MyAssistant.Models
{
    public interface IMyAssistantRepo
    {
        IQueryable<User> Users { get; }
    }
}
