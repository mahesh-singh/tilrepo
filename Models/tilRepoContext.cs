using Microsoft.EntityFrameworkCore;

namespace tilrepo.Models
{
    public class tilRepoContext : DbContext
    {
        public tilRepoContext(DbContextOptions<tilRepoContext> options)
            :base(options)
        {
            
        }

        public DbSet<til> til {get; set;}
    }
}
