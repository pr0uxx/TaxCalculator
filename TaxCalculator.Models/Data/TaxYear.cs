namespace TaxCalculator.Models.Data
{
    /// <summary>
    /// Defines a the tax year by which 
    /// </summary>
    public class TaxYear
    {
        /// <summary>
        /// The year that this tax year applies to
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The ISO 3166 (Alpha-3) Country code that applies to this tax year
        /// </summary>
        public string IsoCountryCode { get; set; } = "GBR";

        /// <summary>
        /// The tax bands that apply to this year
        /// </summary>
        public ICollection<TaxBand> TaxBands { get; set; } = new List<TaxBand>();
    }
}
