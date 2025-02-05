using Core_Proje_Api.Dal.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.Dal.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=DbCoreProje2;integrated security=true");
        }
        public DbSet<Category>Categories { get; set; }
    }
}
