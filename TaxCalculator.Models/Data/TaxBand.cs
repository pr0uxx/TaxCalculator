namespace TaxCalculator.Models.Data
{
    public class TaxBand
    {
        /// <summary>
        /// The primary key identifier for the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The number at which this tax band begins
        /// </summary>
        public decimal RangeLowerBound { get; set; }

        /// <summary>
        /// The number at which this tax band ends
        /// </summary>
        public decimal RangeUpperBound { get; set; }

        /// <summary>
        /// The percentage rate at which this band is taxed
        /// </summary>
        public decimal PercentRate { get; set; }

        //public TaxYear TaxYear { get; set; }

        /// <summary>
        /// The tax year that this applies to
        /// </summary>
        public int TaxYear { get; set; }

        /// <summary>
        /// The ISO 3166 (Alpha-3) Country code that applies to this tax year
        /// </summary>
        public string IsoCountryCode { get; set; } = "GBR";
    }
}
