using FinalExam.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DataBase.DataContext
{
    public class RfamContext : DbContext
    {
        public RfamContext(DbContextOptions<RfamContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LiteratureReferenceEntity>();
        }

        public DbSet<LiteratureReferenceEntity>? literature_reference { get; set; }
    }
}