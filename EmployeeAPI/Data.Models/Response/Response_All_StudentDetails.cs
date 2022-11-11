using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Data.Models.Response
{
    public class Response_All_StudentDetails: Student
    {
        public Guid Id { get; set; } 
        public Gender Gender { get; set; }
    }

   

}
