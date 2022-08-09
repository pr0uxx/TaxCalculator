using Microsoft.EntityFrameworkCore;
using TaxCalculator.Models.Data;

namespace TaxCalculator.EfCore
{
    public class TaxCalculatorContext : DbContext
    {
        public TaxCalculatorContext(DbContextOptions<TaxCalculatorContext> options) : base(options) { }

        public DbSet<TaxYear> TaxYears { get; set; }
        public DbSet<TaxBand> TaxBands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaxYear>()
                .HasKey(e => new { e.IsoCountryCode, e.Year });

            modelBuilder.Entity<TaxBand>()
                .HasOne<TaxYear>()
                .WithMany(e => e.TaxBands)
                .HasForeignKey(e => new { e.IsoCountryCode, e.TaxYear });

            CreateSeedData(modelBuilder);
        }

        protected void CreateSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxYear>()
                .HasData(new TaxYear
                {
                    Year = 2022,
                    IsoCountryCode = "GBR"
                });

            modelBuilder.Entity<TaxBand>()
                    .HasData(new TaxBand
                    {
                        Id = 1,
                        IsoCountryCode = "GBR",
                        TaxYear = 2022,
                        RangeLowerBound = 0,
                        RangeUpperBound = 5000,
                        PercentRate = 0
                    },
                    new TaxBand
                    {
                        Id = 2,
                        IsoCountryCode = "GBR",
                        TaxYear = 2022,
                        RangeLowerBound = 5000,
                        RangeUpperBound = 20000,
                        PercentRate = 20
                    },
                    new TaxBand
                    {
                        Id = 3,
                        IsoCountryCode = "GBR",
                        TaxYear = 2022,
                        RangeLowerBound = 20000,
                        RangeUpperBound = 0,
                        PercentRate = 40
                    }
                );
        }
    }
}