namespace MyAssistant.Models
{
    public class MyAssistantRepoClass:IMyAssistantRepo
    {
        public MyAssistantContext context { get; set; }
        public MyAssistantRepoClass(MyAssistantContext temp)
        {
            context = temp;
        }

        public IQueryable<User> Users => context.user;
    }
}
