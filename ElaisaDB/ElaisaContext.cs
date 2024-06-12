using Microsoft.EntityFrameworkCore;

namespace ElaisaDB;
public class ElaisaContext : DbContext
{
    public ElaisaContext(DbContextOptions<ElaisaContext> options) : base(options)
    {

    }

    public DbSet<MessageRequest> MessageRequests { get; set; }

    
}

