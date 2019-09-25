using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Repository
{
    public interface IHrEmployeeRepository
    {
        IEnumerable<HrEmployee> GetAll();
        HrEmployee Get(object id);
        int GetSumOfSalaries();
    }
}