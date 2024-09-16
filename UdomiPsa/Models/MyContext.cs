using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UdomiPsa.Models
{
    public class MyContext : IdentityDbContext
    {
        public MyContext(DbContextOptions options): base(options) { 
        
        }
        public DbSet<Vrsta> Vrstas { get; set; }
        public DbSet<Pas> Pass { get; set; }

    }
}
