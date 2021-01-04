using Microsoft.EntityFrameworkCore;

namespace DishesApi.Models
{
    public class DishesContext : DbContext
    {
        public DishesContext(DbContextOptions<DishesContext> options)
            : base(options)
        {
        }

        public DbSet<Dishes> DishesItems { get; set; }

    }
}