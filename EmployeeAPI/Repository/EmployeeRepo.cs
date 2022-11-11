using EmployeeAPI.Interfaces;
using EmployeeAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmployeeAPI.Data.Models.Response;
using Dapper;
using EmployeeAPI.Interfaces.IUtilities;
using Microsoft.Extensions.Options;
using EmployeeAPI.Data.Models;
using EmployeeAPI.Data.Models.Request;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConfigurationSettings _configuration;
        private readonly IOptions<ExceptionHandling> _exceptionHandling;
        private readonly ILoggerService<IEmployeeRepo> _loggerService;
        public EmployeeRepo(IConfigurationSettings configurationSettings, IOptions<ExceptionHandling> exceptionHandling, ILoggerService<IEmployeeRepo> loggerService)
        {
            _configuration = configurationSettings;
            _exceptionHandling = exceptionHandling;
            _loggerService = loggerService;
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
                await _loggerService.LogError($"[{ DateTime.Now:hh:ss:tt}] :GetEmployee : Information => {ex}{Environment.NewLine}", _exceptionHandling.Value.Path);
                return null;
            }
            return result;
        }
        public async Task<IEnumerable<Response_All_StudentDetails>> GetStudents()
        {
            var result = new List<Response_All_StudentDetails>();
            try
            {
                using (var conn = new SqlConnection(_configuration.MyStudentConnectionString))
                {
                    var sql = "select FirstName, LastName, g.Description from StudentAdminPortalDb.dbo.Gender g inner join StudentAdminPortalDb.dbo.Student s on g.Id = s.GenderId";
                    var response = await conn.QueryAsync<Response_All_StudentDetails, Gender, Response_All_StudentDetails>(sql, (student, gender) => {
                        student.Gender = gender; 
                        return student;
                    }, splitOn: "Description" // what column to retrieve
                    );
                    result = response.AsList();
                }
            }
            catch (Exception ex)
            {
                await _loggerService.LogError($"[{ DateTime.Now:hh:ss:tt}] :GetStudents : Information => {ex}{Environment.NewLine}", _exceptionHandling.Value.Path);
                return null;
            }
            return result;

        }
        public async Task<IEnumerable<Response_Student_Details>> GetOneStudent(Request_Student_Details request)
        {
            var result = new List<Response_Student_Details>();
            try
            {
                using (var conn = new SqlConnection(_configuration.MyStudentConnectionString))
                {
                    // prepared statements
                    var pm = new DynamicParameters();
                    pm.Add("@FirstName", request.FirstName);
                    pm.Add("@LastName", request.LastName);

                    // querying stored procedure
                    var response = await conn.QueryAsync<Response_Student_Details>("SelectStudents", pm, commandType: System.Data.CommandType.StoredProcedure);

                    result = response.AsList();
                }
            }
            catch (Exception ex)
            {
                await _loggerService.LogError($"[{ DateTime.Now:hh:ss:tt}] :GetOneStudent : Information => {ex}{Environment.NewLine}", _exceptionHandling.Value.Path);
                return null;
            }
            return result;
        }

        public async Task<int> UpdateCurrencyRate(Request_Update_Student_Details request)
        {
            int iStatus = 0;
            try
            {
                var Query = string.Empty;
                var ps = new DynamicParameters();
                if (request.Id.ToString().Trim() != "")
                {
                    Query = "SELECT count(1) FROM StudentAdminPortalDb.dbo.Student WHERE Id = @Id";
                    ps.Add("@Id", request.Id);

                    using (var conn = new SqlConnection(_configuration.MyStudentConnectionString))
                    {
                        // return a single value
                        iStatus = Convert.ToInt32(conn.ExecuteScalar(Query, ps, commandType: System.Data.CommandType.Text));

                        if (iStatus > 0)
                        {
                            // update
                            Query = "UPDATE dbo.Student SET FirstName=@FirstName, LastName=@LastName, DateOfBirth=@DateOfBirth, Email=@Email, Mobile=@Mobile, GenderId=@GenderId WHERE Id=@Id";

                        }
                        else
                        {
                            Query = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _loggerService.LogError($"[{ DateTime.Now:hh:ss:tt}] :UpdateCurrencyRate : Information => {ex}{Environment.NewLine}", _exceptionHandling.Value.Path);
            }
            throw new NotImplementedException();
        }


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
