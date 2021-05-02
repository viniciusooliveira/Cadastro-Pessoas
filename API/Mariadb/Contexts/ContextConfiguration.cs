using Mariadb.Maps;
using Microsoft.EntityFrameworkCore;

namespace Mariadb.Contexts
{
    public class ContextConfiguration
    {
        public static void OnModelCreatingConfigure(ModelBuilder modelBuilder)
        {
            // Persons
            modelBuilder.ApplyConfiguration(new PersonMap());
        }
    }
}