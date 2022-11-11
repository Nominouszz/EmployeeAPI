using EmployeeAPI.Interfaces.IUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Repository
{
    public class LoggerService<T> : ILoggerService<T> where T : class // constraining that it will be class into the type parameter
    {
        // microsoft logging extension
        private readonly ILogger<T> _logger;
        public LoggerService(ILogger<T> logger)
        {
            _logger = logger;
        }
        public async Task LogError(string errorInformation, string path)
        {
            try
            {
                _logger.LogError(errorInformation);
                var fileName = $"{DateTime.Now:yyyyMMdd}.txt";

                DirectoryCheck(path);

                await File.AppendAllTextAsync(Path.Combine(path, fileName), errorInformation);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        void DirectoryCheck(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
