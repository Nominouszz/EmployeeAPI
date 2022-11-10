using EmployeeAPI.Interfaces;
using EmployeeAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmployeeAPI.Data.Models.Response;
using Dapper;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConfigurationSettings _configuration;
        public EmployeeRepo(IConfigurationSettings configurationSettings)
        {
            _configuration = configurationSettings;
        }

        public async Task<IEnumerable<Response_Employee_Detail>> GetEmployee()
        {
            var result = new List<Response_Employee_Detail>();
            try
            {
                using (var conn = new SqlConnection(_configuration.MyConnectionString))
                {
                    var response = await conn.QueryAsync<Response_Employee_Detail>("SELECT * FROM dmvdb.dbo.Employee", null, commandType: System.Data.CommandType.Text);
                    result = response.AsList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return result;
        }
        public async


        /*
        public List<Employee> GetAllEmployee()
        {
            var empList = new List<Employee>();
            empList.Add( new Employee() { Id=1, FirstName="Darryl", LastName="Villanueva" });
            empList.Add(new Employee() { Id = 1, FirstName = "Dominic", LastName = "Villanueva" });
            return empList;
        }
        */
    }
}
