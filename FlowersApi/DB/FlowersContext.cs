using FlowersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowersApi.DB
{
    public class FlowersContext : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }

        public FlowersContext(DbContextOptions<FlowersContext> options): base(options)
        {

        }
    }
}
