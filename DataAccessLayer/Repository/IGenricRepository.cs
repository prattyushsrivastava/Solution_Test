
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

        public IEnumerable<Guard> SignInBadge(string fname,string lname, int ecode);

        public IEnumerable<Guard> SignOutBadge(int id);

        public IEnumerable<Guard> GetBadges();

        public IEnumerable<Guard> GetBadgeReport(string fname, string lname, DateTime signIN, DateTime signOut,string status);

        public IEnumerable<BadgeOut> GetBadgeOut();

        public IEnumerable<BadgeOut> GetBadgeQueue();

        public IEnumerable<Guard> SignOutPage(string TBadge);

        //public Task<IEnumerable<User>> RegisterUser(User model);

        //public Task<IEnumerable<LoginViewModel>> LoginUser(LoginViewModel model);
    }
}
