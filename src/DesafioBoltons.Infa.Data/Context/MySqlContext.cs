using DesafioBoltons.Domain.Entities;
using DesafioBoltons.Infa.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DesafioBoltons.Infa.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }
        public DbSet<NFeEntity> NFes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NFeEntity>(new NFeMap().Configure);
        }
    }
}
