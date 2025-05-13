using Microsoft.EntityFrameworkCore;

namespace MyAssistant.Models
{
    public class MyAssistantContext:DbContext
    {
        public MyAssistantContext(DbContextOptions<MyAssistantContext> options)
            : base(options) { }
        public DbSet<User> user => Set<User>();
    }
}
