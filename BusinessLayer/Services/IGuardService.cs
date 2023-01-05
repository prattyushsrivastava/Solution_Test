using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IGuardService
    {
        public IEnumerable<Guard> SignInBadge(string fname, string lname, int ecode);

        public IEnumerable<Guard> SignOutBadge(int id);

        public IEnumerable<Guard> GetBadges();

        public IEnumerable<Guard> GetBadgeReport(string fname, string lname, DateTime signin, DateTime signout, string status);

        public IEnumerable<Guard> SignOutPage(string TempBadge);

        public IEnumerable<BadgeOut> GetBadgeOut();

        public IEnumerable<BadgeOut> GetBadgeQueue();


    }
}
