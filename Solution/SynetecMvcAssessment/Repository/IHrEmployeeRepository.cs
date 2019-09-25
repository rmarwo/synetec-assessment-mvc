using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Repository
{
    public interface IHrEmployeeRepository : IRepository<HrEmployee>
    {
        int GetSumOfSalaries();
    }
}