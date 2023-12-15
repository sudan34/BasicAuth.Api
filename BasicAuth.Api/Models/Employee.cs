using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuth.Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Id = 1, FirstName= "Madhu", LastName= "Sudan", Gender="M",City="Palpa", IsActive=true},
                new Employee { Id = 2, FirstName= "Sudip", LastName= "Bhattarai", Gender="M",City="Rampur", IsActive=true},
            };
            return employees;
        }
    }
}