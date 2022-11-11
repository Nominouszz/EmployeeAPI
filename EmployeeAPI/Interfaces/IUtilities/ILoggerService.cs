using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces.IUtilities
{
    public interface ILoggerService<T>
    {
        Task LogError(string errorInformation, string path);
    }
}
