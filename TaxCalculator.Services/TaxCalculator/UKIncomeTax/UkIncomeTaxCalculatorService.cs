using TaxCalculator.Models.Data;
using TaxCalculator.Repository.Interface;
using TaxCalculator.Services.TaxCalculator.Interface;

namespace TaxCalculator.Services.TaxCalculator.UKIncomeTax
{
    public class UkIncomeTaxCalculatorService : IIncomeTaxCalculatorService
    {
        private readonly IRepository<TaxBand> _taxBandRepository;
        private const string IsoCountryCode = "GBR";

        public UkIncomeTaxCalculatorService(IRepository<TaxBand> taxBandRepository)
        {
            _taxBandRepository = taxBandRepository;
        }

        public async Task<decimal> GetTaxForGrossAmountAsync(decimal grossAmount, int year, CancellationToken ct = default)
        {
            var taxBands = await _taxBandRepository
                .GetWhereAsync(taxBand => taxBand.TaxYear == year && taxBand.IsoCountryCode == IsoCountryCode, ct);

            decimal total = 0;

            foreach (var taxBand in taxBands)
            {
                total += GetTaxAmountForTaxBand(taxBand, grossAmount);
            }

            return Math.Round(total, 2);
        }

        public decimal GetTaxAmountForTaxBand(TaxBand taxBand, decimal grossAmount)
        {
            //shortcut any calculations when we know the result will be 0
            if (taxBand.RangeLowerBound > grossAmount || taxBand.PercentRate == 0) return 0;

            var start = grossAmount - taxBand.RangeLowerBound;
            var end = taxBand.RangeUpperBound < grossAmount ? taxBand.RangeUpperBound : grossAmount;

            if (start + end == 0) return 0;

            var taxable = end == 0 ? start : Math.Max(taxBand.RangeLowerBound, end) - Math.Min(taxBand.RangeLowerBound, end);
            //var taxable = Math.Max(start, end) - Math.Min(start, end);

            return (taxable / 100) * taxBand.PercentRate;
        }
    }
}
