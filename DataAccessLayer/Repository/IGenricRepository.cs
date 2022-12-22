
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IGenricRepository
    {
        public IEnumerable<Employee> GetEmployees(string fname, string lname);
    }
}
