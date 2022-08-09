using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Models.DataTransferObjects;
using TaxCalculator.Services.SalaryCalculator.NetSalaryCalculator;
using TaxCalculator.Services.SalaryCalculator.YearlyToMonthlyCalculator;
using TaxCalculator.Services.TaxCalculator.Interface;

namespace TaxCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeTaxController : ControllerBase
    {
        private readonly IIncomeTaxCalculatorService _incomeTaxCalculatorService;
        private readonly IYearlyToMonthlyCalculatorService _yearlyToMonthlyCalculator;
        private readonly INetSalaryCalculatorService _netSalaryCalculator;

        public IncomeTaxController(IIncomeTaxCalculatorService incomeTaxCalculatorService,
            IYearlyToMonthlyCalculatorService yearlyToMonthlyCalculator, INetSalaryCalculatorService netSalaryCalculator)
        {
            _incomeTaxCalculatorService = incomeTaxCalculatorService;
            _yearlyToMonthlyCalculator = yearlyToMonthlyCalculator;
            _netSalaryCalculator = netSalaryCalculator;
        }

        /// <summary>
        /// Returns the gross salary, net salary and amount taxed per month and year for the provided gross annual salary
        /// </summary>
        /// <param name="grossAnnualSalary">The amount you get paid in a year, before deductions</param>
        /// <param name="year">The year you want tax information for</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 60 * 10, VaryByQueryKeys = new[] { "grossAnnualSalary", "year" })]
        public async Task<IncomeTaxDto> GetIncomeTaxForGrossAnnualSalaryAsync([FromQuery] decimal grossAnnualSalary,
            [FromQuery] int year, CancellationToken ct)
        {
            var totalTax = await _incomeTaxCalculatorService.GetTaxForGrossAmountAsync(grossAnnualSalary, year, ct);

            var result = new IncomeTaxDto
            {
                GrossAnnualSalary = grossAnnualSalary,
                GrossMonthlySalary = _yearlyToMonthlyCalculator.GetMonthlyAmountFromYearlyAmount(grossAnnualSalary),
                AnnualTaxPaid = totalTax,
                MonthlyTaxPaid = _yearlyToMonthlyCalculator.GetMonthlyAmountFromYearlyAmount(totalTax),
                NetAnnualSalary = _netSalaryCalculator.GetNetSalary(grossAnnualSalary, totalTax),
                NetMonthlySalary = _netSalaryCalculator.GetMonthlyNetSalary(grossAnnualSalary, totalTax)
            };

            return result;
        }
    }
}
