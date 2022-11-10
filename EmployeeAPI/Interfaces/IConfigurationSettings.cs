using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces
{
    public interface IConfigurationSettings
    {
        public string MyConnectionString { get; set; }
        public string MyStudentConnectionString { get; set; }
    }
}
