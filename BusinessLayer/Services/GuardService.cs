using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class GuardService:IGuardService
    {

        private readonly IGenricRepository _repo;

        public GuardService(IGenricRepository repo)
        {
            this._repo = repo; 
        }

        public IEnumerable<BadgeOut> GetBadgeOut()
        {
            return _repo.GetBadgeOut();
        }

        public IEnumerable<BadgeOut> GetBadgeQueue()
        {
            return _repo.GetBadgeQueue();
        }

        public IEnumerable<Guard> GetBadgeReport(string fname, string lname, DateTime signin, DateTime signout,string status)
        {

            return _repo.GetBadgeReport(fname,lname,signin,signout,status);
        }

        public IEnumerable<Guard> GetBadges()
        {
            return _repo.GetBadges();
        }

        public IEnumerable<Guard> SignInBadge(string fname, string lname, int ecode)

        {
            if (ecode == null ||fname==null )
            {
                return null;
            }
            return _repo.SignInBadge(fname, lname, ecode);
        }

        public IEnumerable<Guard> SignOutBadge(int id)
        {
            if (id == 0)
            {
                return null;
            }
            return _repo.SignOutBadge(id);
        }

        public IEnumerable<Guard> SignOutPage(string TempBadge)
        {
            if(TempBadge == null)
            {
                return null;
            }   
            return _repo.SignOutPage(TempBadge);
        }
    }
}
