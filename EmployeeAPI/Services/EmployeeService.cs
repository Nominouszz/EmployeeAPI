using EmployeeAPI.Data.Models.Response;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Interfaces.IServices;
using EmployeeAPI.Model;
using EmployeeAPI.Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepo _employeerepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeerepo = employeeRepo;
        }

        public async Task<ResponseModel<IEnumerable<Response_Employee_Detail>>> GetEmployee()
        {
            var result = new ResponseModel<IEnumerable<Response_Employee_Detail>>();
            try
            {
                var data = await _employeerepo.GetEmployee();
                result.Entity = data;
                result.ReturnStatus = true;
                result.ReturnMessage = "Success";
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        /*
public List<Employee> GetAllEmployee()
{
   var empList = _employeerepo.GetAllEmployee();
   return empList;
}
*/


    }
}
