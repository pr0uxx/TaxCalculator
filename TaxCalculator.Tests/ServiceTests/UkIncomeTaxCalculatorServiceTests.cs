using Moq;
using System.Linq.Expressions;
using TaxCalculator.Models.Data;
using TaxCalculator.Repository.Interface;
using TaxCalculator.Services.TaxCalculator.UKIncomeTax;

namespace TaxCalculator.Tests.ServiceTests
{
    [TestClass]
    public class UkIncomeTaxCalculatorServiceTests
    {
        [TestMethod]
        [DynamicData(nameof(GetTaxAmountForTaxBand_ReturnsExpected_ForProvidedTaxBand_Data), DynamicDataSourceType.Method)]
        public void GetTaxAmount_ForTaxBand_ReturnsExpected_ForProvidedTaxBand_And_ProvidedGrossAmount
            (TaxBand taxBand, decimal grossAmount, decimal expected)
        {
            var underTest = new UkIncomeTaxCalculatorService(null);

            var actual = underTest.GetTaxAmountForTaxBand(taxBand, grossAmount);

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetTaxAmountForTaxBand_ReturnsExpected_ForProvidedTaxBand_Data()
        {
            yield return new object[]
            {
                new TaxBand
                {
                    RangeLowerBound = 0,
                    RangeUpperBound = 5000,
                    PercentRate = 0
                },
                1000m,
                0m
            };
            yield return new object[]
            {
                new TaxBand
                {
                    RangeLowerBound = 0,
                    RangeUpperBound = 5000,
                    PercentRate = 0
                },
                10000m,
                0m
            };
            yield return new object[]
            {
                new TaxBand
                {
                    RangeLowerBound = 0,
                    RangeUpperBound = 5000,
                    PercentRate = 10
                },
                10000m,
                500m
            };
            yield return new object[]
            {
                new TaxBand
                {
                    RangeLowerBound = 5000,
                    RangeUpperBound = 10000,
                    PercentRate = 10
                },
                10000m,
                500m
            };
            yield return new object[]
            {
                new TaxBand
                {
                    RangeLowerBound = 20000,
                    RangeUpperBound = 0,
                    PercentRate = 40
                },
                40000m,
                8000m
            };
            yield return new object[]
            {
                new TaxBand
                {
                    RangeLowerBound = 20000,
                    RangeUpperBound = 0,
                    PercentRate = 40
                },
                10000m,
                0m
            };
            yield return new object[]
            {
                new TaxBand
                {
                    RangeLowerBound = 5000,
                    RangeUpperBound = 20000,
                    PercentRate = 20
                },
                20000m,
                3000m
            };
        }

        [TestMethod]
        [DynamicData(nameof(GetTaxForGrossAmount_ReturnsExpected_ForProvidedTaxBands_Data), DynamicDataSourceType.Method)]
        public async Task GetTaxForGrossAmount_ReturnsExpected_ForProvidedTaxBands
            (List<TaxBand> taxBands, decimal grossAmount, decimal expected)
        {
            var mockTaxBandRepository = new Mock<IRepository<TaxBand>>();
            mockTaxBandRepository.Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<TaxBand, bool>>>(), default))
                .ReturnsAsync(taxBands);

            var underTest = new UkIncomeTaxCalculatorService(mockTaxBandRepository.Object);

            var actual = await underTest.GetTaxForGrossAmountAsync(grossAmount, 0);

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetTaxForGrossAmount_ReturnsExpected_ForProvidedTaxBands_Data()
        {
            yield return new object[]
            {
                new List<TaxBand>
                {
                    new()
                    {
                        RangeLowerBound = 0,
                        RangeUpperBound = 5000,
                        PercentRate = 0
                    },
                    new()
                    {
                        RangeLowerBound = 5000,
                        RangeUpperBound = 20000,
                        PercentRate = 20
                    },
                    new()
                    {
                        RangeLowerBound = 20000,
                        RangeUpperBound = 0,
                        PercentRate = 40
                    }
                },
                10000m,
                1000m
            };
            yield return new object[]
            {
                new List<TaxBand>
                {
                    new()
                    {
                        RangeLowerBound = 0,
                        RangeUpperBound = 5000,
                        PercentRate = 0
                    },
                    new()
                    {
                        RangeLowerBound = 5000,
                        RangeUpperBound = 20000,
                        PercentRate = 20
                    },
                    new()
                    {
                        RangeLowerBound = 20000,
                        RangeUpperBound = 0,
                        PercentRate = 40
                    }
                },
                40000m,
                11000m
            };
            yield return new object[]
            {
                new List<TaxBand>
                {
                    new()
                    {
                        RangeLowerBound = 0,
                        RangeUpperBound = 5000,
                        PercentRate = 0
                    },
                    new()
                    {
                        RangeLowerBound = 5000,
                        RangeUpperBound = 20000,
                        PercentRate = 20
                    },
                    new()
                    {
                        RangeLowerBound = 20000,
                        RangeUpperBound = 0,
                        PercentRate = 40
                    }
                },
                20000m,
                3000m
            };
            yield return new object[]
            {
                new List<TaxBand>
                {
                    new()
                    {
                        RangeLowerBound = 0,
                        RangeUpperBound = 5000,
                        PercentRate = 0
                    },
                    new()
                    {
                        RangeLowerBound = 5000,
                        RangeUpperBound = 20000,
                        PercentRate = 20
                    },
                    new()
                    {
                        RangeLowerBound = 20000,
                        RangeUpperBound = 0,
                        PercentRate = 40
                    }
                },
                20000.05m,
                3000.02m
            };
        }
    }
}
