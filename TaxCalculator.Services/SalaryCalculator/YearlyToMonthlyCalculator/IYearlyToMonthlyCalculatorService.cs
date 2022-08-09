namespace TaxCalculator.Services.SalaryCalculator.YearlyToMonthlyCalculator
{
    public interface IYearlyToMonthlyCalculatorService
    {
        decimal GetMonthlyAmountFromYearlyAmount(decimal yearlyAmount);
    }
}
