using Dapper;
using MvcJsonWebAPI_Clone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcJsonWebAPI_Clone.Repository
{
    public class EmployeeRepository
    {
        static string connString = @"Data Source=.; Initial Catalog=Northwind; Integrated Security=True; MultipleActiveResultSets=True";

        public List<Emp> GetAllEmployees()
        {
            List<Emp> emps;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "select * from Employees";
                List<Emp> employees = conn.Query<Emp>(sql).ToList(); //左邊是List，右邊是IEnumerable，所以右邊要加上ToList()
                emps = conn.Query<Emp>("select * from Employees").ToList();
            }
            return emps;
        }

    }
}