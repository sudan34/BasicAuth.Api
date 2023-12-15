using BasicAuth.Api.BasicAuth;
using BasicAuth.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicAuth.Api.Controllers
{
    [BasicAuthenticationAttribute]
    public class EmployeeController : ApiController
    {
        public List<Employee> GetEmployees() 
        { 
            return Employee.GetEmployees();
        }
    }
}
