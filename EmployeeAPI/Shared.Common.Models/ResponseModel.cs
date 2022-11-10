using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Shared.Common.Models
{
    public class ResponseModel<T>
    {
        public T Entity;
        public bool ReturnStatus { get; set; }
        public string ReturnMessage { get; set; }

        public ResponseModel()
        {
            ReturnMessage = "An Error Occured while processing the request!";
            ReturnStatus = false;
        }

    }
}
