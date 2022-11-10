using EmployeeAPI.Data.Models.Response;
using EmployeeAPI.Model;
using EmployeeAPI.Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces.IServices
{
    public interface IEmployeeService
    {
        //List<Employee> GetAllEmployee();
        Task <ResponseModel<IEnumerable<Response_Employee_Detail>>> GetEmployee();
    }
}
