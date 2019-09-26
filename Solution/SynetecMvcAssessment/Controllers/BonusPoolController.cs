using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewTestTemplatev2.Core;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repository;

namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        private readonly IHrEmployeeRepository _hrEmployeeRepository;

        public BonusPoolController(IHrEmployeeRepository hrEmployeeRepository)
        {
            _hrEmployeeRepository = hrEmployeeRepository;
        }

        // GET: BonusPool
        public ActionResult Index()
        {
            BonusPoolCalculatorModel model = new BonusPoolCalculatorModel();
            model.AllEmployees = _hrEmployeeRepository.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            int selectedEmployeeId = model.SelectedEmployeeId;
            int totalBonusPool = model.BonusPoolAmount;

            //load the details of the selected employee using the ID
            HrEmployee hrEmployee = _hrEmployeeRepository.Get(selectedEmployeeId);
            
            int employeeSalary = hrEmployee.Salary;

            //get the total salary budget for the company
            int totalSalary = _hrEmployeeRepository.GetSumOfSalaries();

            //calculate the bonus allocation for the employee
            BonusPoolCalculator calculator = new BonusPoolCalculator(totalSalary, totalBonusPool);
            decimal bonusAllocation = calculator.CalculateBonusAllocation(employeeSalary);

            BonusPoolCalculatorResultModel result = new BonusPoolCalculatorResultModel();
            result.hrEmployee = hrEmployee;
            result.bonusPoolAllocation = bonusAllocation;
            
            return View(result);
        }
    }
}