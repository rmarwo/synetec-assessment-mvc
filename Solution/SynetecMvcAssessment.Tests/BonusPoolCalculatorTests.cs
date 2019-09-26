using System;
using System.Collections.Generic;
using InterviewTestTemplatev2.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SynetecMvcAssessment.Tests
{
    [TestClass]
    public class BonusPoolCalculatorTests
    {
        public static IEnumerable<object[]> GetBonusPoolValidTestData() =>
            new List<object[]>
            {
                new object[] { new BonusPoolTestData(100m, 123456m, 15m) },
                new object[] { new BonusPoolTestData(1000000m, 100000m, 654321.12m) },
                new object[] { new BonusPoolTestData(10000m, 100000m, 0m) },
                new object[] { new BonusPoolTestData(10000000m, 0m, 654321.12m) },
                new object[] { new BonusPoolTestData(0m, 0m, 0m) }
            };

        public static IEnumerable<object[]> GetEmployeeSalaryMoreThanBudgetTestData() =>
            new List<object[]>
            {
                new object[] { new BonusPoolTestData(10m, 100m, 1000m) },
                new object[] { new BonusPoolTestData(0, 100m, 1000m) }
            };


        [DataTestMethod]
        [DynamicData(nameof(GetBonusPoolValidTestData), DynamicDataSourceType.Method)]
        public void BonusIsGivenToTwoDecimalPlaces(BonusPoolTestData testData)
        {
            var calculator = new BonusPoolCalculator(testData.WageBudget, testData.BonusPoolValue);

            decimal bonus = calculator.CalculateBonusAllocation(testData.EmployeeSalary);
            decimal bonusRounded = Decimal.Round(bonus, 2);

            Assert.AreEqual(bonusRounded, bonus);
        }
        
        [DataTestMethod]
        [DynamicData(nameof(GetBonusPoolValidTestData), DynamicDataSourceType.Method)]
        public void BonusPercentageOfPoolEqualsSalaryPercentageOfWageBudget(BonusPoolTestData testData)
        {
            var calculator = new BonusPoolCalculator(testData.WageBudget, testData.BonusPoolValue);
            decimal basePercentage = testData.WageBudget != 0 ? testData.EmployeeSalary / testData.WageBudget : 0;
            decimal expectedBonus = Math.Floor(basePercentage * testData.BonusPoolValue * 100) / 100;

            decimal bonus = calculator.CalculateBonusAllocation(testData.EmployeeSalary);

            Assert.AreEqual(expectedBonus, bonus);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetEmployeeSalaryMoreThanBudgetTestData), DynamicDataSourceType.Method)]
        public void EmployeeSalaryCannotBeMoreThanWageBudget(BonusPoolTestData testData)
        {
            var calculator = new BonusPoolCalculator(testData.WageBudget, testData.BonusPoolValue);

            Action calculate = () => calculator.CalculateBonusAllocation(testData.EmployeeSalary);

            Assert.ThrowsException<ArgumentOutOfRangeException>(calculate, "Employee salary cannot be greater than the wage budget");
        }
    }
}
