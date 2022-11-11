using EmployeeAPI.Data.Models.Request;
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
        Task<ResponseModel<IEnumerable<Response_All_StudentDetails>>> GetStudents();
        Task<ResponseModel<IEnumerable<Response_Student_Details>>> GetOneStudent(Request_Student_Details request);
    }
}
