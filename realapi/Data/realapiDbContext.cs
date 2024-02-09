using Microsoft.EntityFrameworkCore;
using realapi.models;

namespace realapi.Data
{
    public class realapiDbContext:DbContext
    {
        public realapiDbContext(DbContextOptions<realapiDbContext> options):base(options)
        {
            
        }
        public DbSet<Contact> contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=192.168.2.16;database=demo;User ID=sa;Password=v0x123#;TrustServerCertificate=true");
        }
    }
    
}