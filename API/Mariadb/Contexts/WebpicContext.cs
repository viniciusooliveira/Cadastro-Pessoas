using Domain.Contexts.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mariadb.Contexts
{
    public class WebpicContext : DbContext, IWebpicContext 
    {
        public WebpicContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ContextConfiguration.OnModelCreatingConfigure(modelBuilder);
        }
    }
}