using EmployeeAPI.Data.Models.Request;
using EmployeeAPI.Data.Models.Response;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Interfaces.IServices;
using EmployeeAPI.Model;
using EmployeeAPI.Shared.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeerepo;
        private readonly ILogger<IEmployeeService> _logger;
        public EmployeeService(IEmployeeRepo employeeRepo, ILogger<IEmployeeService> logger)
        {
            _logger = logger;
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
                _logger.LogError(nameof(GetEmployee), ex);
            }
            return result;
        }

        public async Task<ResponseModel<IEnumerable<Response_All_StudentDetails>>> GetStudents()
        {
            var result = new ResponseModel<IEnumerable<Response_All_StudentDetails>>();
            try
            {
                var data = await _employeerepo.GetStudents();
                result.Entity = data;
                result.ReturnStatus = true;
                result.ReturnMessage = "Success";
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(GetStudents), ex);
            }
            return result;
        }

        public async Task<ResponseModel<IEnumerable<Response_Student_Details>>> GetOneStudent(Request_Student_Details request)
        {
            var result = new ResponseModel<IEnumerable<Response_Student_Details>>();
            try
            {
                var data = await _employeerepo.GetOneStudent(request);
                result.Entity = data;
                result.ReturnStatus = true;
                result.ReturnMessage = "Success";
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(GetOneStudent), ex);
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
