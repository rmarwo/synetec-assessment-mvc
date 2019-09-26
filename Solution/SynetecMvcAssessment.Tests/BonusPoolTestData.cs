using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssessment.Tests
{
    public class BonusPoolTestData
    {
        public decimal WageBudget { get; set; }
        public decimal BonusPoolValue { get; set; }
        public decimal EmployeeSalary { get; set; }

        public BonusPoolTestData(decimal wageBudget, decimal bonusPoolValue, decimal employeeSalary)
        {
            WageBudget = wageBudget;
            BonusPoolValue = bonusPoolValue;
            EmployeeSalary = employeeSalary;
        }
    }
}
