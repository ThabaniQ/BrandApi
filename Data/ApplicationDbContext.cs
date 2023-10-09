using BrandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandApi.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BrandImages> Brands { get; set; }
    }
}
