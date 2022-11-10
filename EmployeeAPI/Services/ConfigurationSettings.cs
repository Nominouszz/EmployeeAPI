using EmployeeAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        public string MyConnectionString { get; set; }
        public string MyStudentConnectionString { get; set; }

        public ConfigurationSettings()
        {
            MyConnectionString = "Data Source=.;Initial Catalog=dmvdb;Integrated Security=True";
            MyStudentConnectionString = "Data Source=.;Initial Catalog=StudentAdminPortalDb;Integrated Security=True";
        }
    }
}
