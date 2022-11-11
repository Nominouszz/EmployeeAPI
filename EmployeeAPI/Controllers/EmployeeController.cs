using EmployeeAPI.Data.Models.Request;
using EmployeeAPI.Interfaces.IServices;
using EmployeeAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var emp = await _employeeService.GetEmployee();
            return Ok(emp.Entity);
        }
        
        [HttpGet]
        public async Task<IActionResult> FetchStudentDetails()
        {
            var result = await _employeeService.GetStudents();
            return Ok(result.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> FetchOneStudent(Request_Student_Details request)
        {
            var result = await _employeeService.GetOneStudent(request);
            return Ok(result.Entity);
        }

    }
}
