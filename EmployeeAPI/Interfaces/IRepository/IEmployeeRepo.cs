using EmployeeAPI.Data.Models.Response;
using EmployeeAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces
{
    public interface IEmployeeRepo
    {
        //List<Employee> GetAllEmployee();
        Task<IEnumerable<Response_Employee_Detail>> GetEmployee();
        
    }
}
