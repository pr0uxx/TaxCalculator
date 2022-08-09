namespace TaxCalculator.Services.TaxCalculator.Interface
{
    public interface IIncomeTaxCalculatorService
    {
        Task<decimal> GetTaxForGrossAmountAsync(decimal grossAmount, int year, CancellationToken ct = default);
    }
}
