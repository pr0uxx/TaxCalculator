namespace TaxCalculator.Services.SalaryCalculator.NetSalaryCalculator
{
    public interface INetSalaryCalculatorService
    {
        decimal GetMonthlyNetSalary(decimal grossAmount, decimal taxedAmount);
        decimal GetNetSalary(decimal grossAmount, decimal taxedAmount);
    }
}
