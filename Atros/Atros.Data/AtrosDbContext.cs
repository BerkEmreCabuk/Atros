using Atros.Data.Entities;
using Atros.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Atros.Data
{
    public class AtrosDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieEvaluation> MovieEvaluations { get; set; }

        public AtrosDbContext():base()
        {

        }
        public AtrosDbContext(DbContextOptions<AtrosDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)=> options.UseSqlite("DataSource=atros.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new MovieEvaluationConfiguration());
            modelBuilder.ApplyConfiguration(new SeedData());

            base.OnModelCreating(modelBuilder);
        }
    }
}
