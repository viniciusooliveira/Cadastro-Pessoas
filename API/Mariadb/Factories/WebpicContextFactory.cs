using CrossCutting.Settings;
using Mariadb.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging.Abstractions;

namespace Mariadb.Factories
{
    /// <summary>
    /// Utilizada apenas durante o uso das ferramentas de linha de comando do EF
    /// </summary>
    public class WebpicContextFactory : IDesignTimeDbContextFactory<WebpicContext>
    {
        public WebpicContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebpicContext>();
            var connectionstring = @"Server=localhost;Port=3306;Database=webpic;Uid=root;Pwd=";
            
            optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));

            return new WebpicContext(optionsBuilder.Options);
        }
    }
}