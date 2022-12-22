
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenricRepository : IGenricRepository
    {
        private readonly KitchenerBadgeSystemContext _dbContext;

        public GenricRepository(KitchenerBadgeSystemContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        

        public IEnumerable<Employee> GetEmployees(string fname, string lname)
        {
           
            
            return  _dbContext.Employees.Where(p => (p.FirstName == fname && p.LastName == lname)).ToList();

           
        }
    }
}
