using EmployeeAPI.Data.Models.Request;
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
        Task<IEnumerable<Response_All_StudentDetails>> GetStudents();
        Task<IEnumerable<Response_Student_Details>> GetOneStudent(Request_Student_Details request);
    }
}
