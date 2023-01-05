using DataAccessLayer.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BusinessLayer.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetEmp(string fname, string lname);
    }
}
