using MvcRepostitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRepostitory.Repositories
{
    public class EmployeeRepository
    {
        CmsContext db = new CmsContext();

        public List<Employee> GetAllEmployee()
        {
            var employees = db.Employees.ToList();
            return employees;
        }

    }
}