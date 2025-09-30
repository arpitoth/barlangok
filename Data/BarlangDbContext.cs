using Barlangok.Models;
using Microsoft.EntityFrameworkCore;

namespace Barlangok.Data
{
    public class BarlangDbContext : DbContext
    {
        public BarlangDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BarlangModel> Barlangok {  get; set; }
    }
}
