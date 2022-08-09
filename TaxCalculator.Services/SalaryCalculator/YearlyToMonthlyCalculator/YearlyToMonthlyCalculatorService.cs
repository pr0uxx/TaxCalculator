namespace TaxCalculator.Services.SalaryCalculator.YearlyToMonthlyCalculator
{
    public class YearlyToMonthlyCalculatorService : IYearlyToMonthlyCalculatorService
    {
        public decimal GetMonthlyAmountFromYearlyAmount(decimal yearlyAmount)
        {
            return Math.Round(yearlyAmount / 12, 2);
        }
    }
}
