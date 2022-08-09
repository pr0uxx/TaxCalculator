using TaxCalculator.Services.SalaryCalculator.YearlyToMonthlyCalculator;

namespace TaxCalculator.Services.SalaryCalculator.NetSalaryCalculator
{
    public class NetSalaryCalculator : YearlyToMonthlyCalculatorService, INetSalaryCalculatorService
    {
        public decimal GetMonthlyNetSalary(decimal grossAmount, decimal taxedAmount)
        {
            return Math.Round(GetMonthlyAmountFromYearlyAmount(GetNetSalary(grossAmount, taxedAmount)), 2);
        }

        public decimal GetNetSalary(decimal grossAmount, decimal taxedAmount)
        {
            return Math.Round(grossAmount - taxedAmount, 2);
        }
    }
}
