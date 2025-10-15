using Microsoft.EntityFrameworkCore;
using OrdemServicoApi.Models;

namespace OrdemServicoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }
    }
}