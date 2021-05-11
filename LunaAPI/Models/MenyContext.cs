using Microsoft.EntityFrameworkCore;

namespace LunaAPI.Models {

    public class MenyContext : DbContext {

        public MenyContext(DbContextOptions<MenyContext> options):base(options) {}

        public DbSet<LunaAPI.Models.Food> Food { get; set; }
        public DbSet<LunaAPI.Models.Drinks> Drinks { get; set; }
        
    }
}