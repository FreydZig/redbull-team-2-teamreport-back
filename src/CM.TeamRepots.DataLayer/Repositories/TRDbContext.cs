using System;
using CM.TeamRepots.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CM.TeamRepots.DataLayer.Repositories
{
    public class TRDbContext : DbContext
    {

        public TRDbContext()
        {
        }
        public TRDbContext(DbContextOptions<TRDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(BaseRepository.GetConnection());
        }

        public virtual DbSet<Leaders> Leaders { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }        
}
