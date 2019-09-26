using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Core
{
    public class BonusPoolCalculator : IBonusPoolCalculator
    {
        private readonly decimal _wageBudget;
        private readonly decimal _bonusPoolValue;

        /// <summary>
        /// Creates a new instance of the BonusPoolCalculator.
        /// </summary>
        /// <param name="wageBudget">The total wage budget or sum of all salaries.</param>
        /// <param name="bonusPoolValue">The total value of the bonus pool.</param>
        public BonusPoolCalculator(decimal wageBudget, decimal bonusPoolValue)
        {
            _wageBudget = wageBudget;
            _bonusPoolValue = bonusPoolValue;
        }

        /// <summary>
        /// Calculates the bonus allocation.
        /// </summary>
        /// <param name="employeeSalary">The salary of the employee receiving the bonus</param>
        /// <returns>The bonus allocated to the employee</returns>
        public decimal CalculateBonusAllocation(decimal employeeSalary)
        {
            if (employeeSalary > _wageBudget)
                throw new ArgumentOutOfRangeException("Employee salary cannot be greater than the wage budget");
            if (_wageBudget == 0)
                return 0;
            decimal bonusPercentage = employeeSalary / _wageBudget;
            decimal bonusAllocation = bonusPercentage * _bonusPoolValue;
            return Math.Floor(bonusAllocation * 100) / 100;
        }
    }
}