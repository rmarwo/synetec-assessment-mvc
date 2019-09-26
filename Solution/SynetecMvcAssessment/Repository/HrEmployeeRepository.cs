using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewTestTemplatev2.Data;

namespace InterviewTestTemplatev2.Repository
{
    public class HrEmployeeRepository : IHrEmployeeRepository
    {
        private readonly MvcInterviewV3Entities1 _dbContext;
        public HrEmployeeRepository(MvcInterviewV3Entities1 dbContext)
        {
            _dbContext = dbContext;
        }

        public HrEmployee Get(object id)
        {
            return _dbContext.HrEmployees.Find(id);
        }

        public IEnumerable<HrEmployee> GetAll()
        {
            return _dbContext.HrEmployees.ToList();
        }

        public int GetSumOfSalaries()
        {
            return _dbContext.HrEmployees.Sum(e => e.Salary);
        }
    }
}