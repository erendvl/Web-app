using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class WebappDb:DbContext
    {
        public WebappDb(DbContextOptions<WebappDb> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
