using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService

    {

        private readonly IGenricRepository _repo;

        public EmployeeService(IGenricRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Employee> GetEmp(string fname, string lname)
        {
            return _repo.GetEmployees(fname, lname);
        }
    }
}
