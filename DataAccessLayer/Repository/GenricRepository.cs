
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Identity;
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
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly SignInManager<IdentityUser> signInManager;

        private static Random rnd = new Random();
     

        Guard ob1 = new Guard();

        public GenricRepository(KitchenerBadgeSystemContext dbcontext)
        {
            _dbContext = dbcontext;
           
        }

       

       

        public IEnumerable<Employee> GetEmployees(string fname, string lname)
        {
            var persons = from p in _dbContext.Employees select p;
            if (!string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname))
            {
                persons = persons.Where(p => p.FirstName.StartsWith(fname) && p.LastName.StartsWith(lname));

                return persons.ToList();
            }
            if (!string.IsNullOrEmpty(fname))
            {
                persons = persons.Where(p => p.FirstName.StartsWith(fname));
                return persons.ToList();
            }
            if (!string.IsNullOrEmpty(lname))
            {
                persons = persons.Where(p => p.LastName.StartsWith(lname));
                return persons.ToList();
            }
           




            return  _dbContext.Employees.ToList();

           
        }

        public string SignInBadge(string fname, string lname, int ecode)
        {
            
            const string alphanumericCharacters =
            //"ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            //"abcdefghijklmnopqrstuvwxyz" +
            "0123456789@/#&*?+=!";



            int needLength = 4;



            string randomStr = new string(Enumerable.Range(1, needLength)
                .Select(_ => alphanumericCharacters[rnd.Next(alphanumericCharacters.Length)]).ToArray());

            ob1.FirstName = fname;
            ob1.LastName = lname;
            ob1.EmpCode = ecode;
            ob1.SignIn = DateTime.Now;
            ob1.TemporaryBadge = randomStr;
            _dbContext.Guards.Add(ob1);
            _dbContext.SaveChanges();
            return ob1.TemporaryBadge;
            
        }


        public IEnumerable<Guard> SignOutBadge(int id)
        {
            var f = _dbContext.Guards.FirstOrDefault(x => x.Id == id);
            f.SignOut=DateTime.Now;

            _dbContext.SaveChanges();
            return _dbContext.Guards.ToList();
        }

        public IEnumerable<Guard> GetBadges()
        {
            //var data = (from p in _dbContext.Guards
            //            select new BadgeOut
            //            {
            //                Name = p.FirstName + " " + p.LastName,
            //                TempBadge = p.TemporaryBadge,
            //                SignIn=p.SignIn.ToString(),
            //                SignOut = p.SignOut.ToString(),

            //            }).ToList();


            //foreach (var report in data)
            //{
            //    if (report.SignOut == "0001-01-01 00:00:00.0000000")
            //    {
            //        report.SignOut = "Active";
            //        //report.AssignTime = 0;

            //    }
            //}
            //return data;
            return _dbContext.Guards.ToList();

        }

        public IEnumerable<Guard> GetBadgeReport(string fname, string lname, DateTime signin, DateTime signout, string status)
        {
            if (string.IsNullOrEmpty(fname) && string.IsNullOrEmpty(lname) && signin== DateTime.MinValue
                && signout==DateTime.MinValue && status!="on")
            {
                return _dbContext.Guards.ToList();
            }
            if (string.IsNullOrEmpty(fname) && string.IsNullOrEmpty(lname) && signin== DateTime.MinValue
                && signout==DateTime.MinValue &&status == "on")
            {
                return _dbContext.Guards.Where(x => x.SignOut > DateTime.MinValue).ToList();
            }
            IQueryable<Guard> query = _dbContext.Guards.Where(x => x.FirstName != null);
            if (!string.IsNullOrEmpty(fname))
            {
                query = query.Where(x => x.FirstName.StartsWith(fname));
            }
            if (!string.IsNullOrEmpty(lname))
            {
                query = query.Where(x => x.LastName.StartsWith(lname));
            }
            if (!(signin==DateTime.MinValue))
            {
                query = query.Where(x => x.SignIn >= signin);
            }
            if (!(signout==DateTime.MinValue))
            {
                query = query.Where(x => x.SignIn <= signout);
            }
            if(status == "on")
            {
                query = query.Where(x => x.SignOut > DateTime.MinValue);
            }
            

            return query.ToList();


            //return _dbContext.Guards.Where(p=>p.FirstName==fname && p.LastName==lname).ToList();
        }

        public IEnumerable<BadgeOut> GetBadgeOut()
        {
            
            var data = (from p in _dbContext.Employees
                        join g in _dbContext.Guards on p.EmpCode equals g.EmpCode
                        select new BadgeOut
                        {
                            PhotoUrl = p.PhotoUrl,
                            Name = p.FirstName + " " + p.LastName,
                            TempBadge = g.TemporaryBadge,
                            SignOut=g.SignOut.ToString(),
                            AssignTime = (int)(g.SignOut - g.SignIn).TotalSeconds
                        }).ToList();


            foreach (var report in data)
            {
                if (report.SignOut == "0001-01-01 00:00:00.0000000")
                {
                    //report.SignOut = "Active";
                    report.AssignTime = 0;

                }
            }
            return data;
        }

        public IEnumerable<Guard> SignOutPage(string TBadge)
        {
            var f = _dbContext.Guards.FirstOrDefault(x => x.TemporaryBadge == TBadge);
            if (f != null)
            {
                f.SignOut = DateTime.Now;

                _dbContext.SaveChanges();
                return _dbContext.Guards;

            }
            return null;
            
        }

        public IEnumerable<BadgeOut> GetBadgeQueue()
        {
            var data = (from p in _dbContext.Employees
                        join g in _dbContext.Guards on p.EmpCode equals g.EmpCode
                        select new BadgeOut
                        {
                            PhotoUrl = p.PhotoUrl,
                            Name = p.FirstName + " " + p.LastName,
                            TempBadge = g.TemporaryBadge,
                            SignOut = g.SignOut.ToString(),
                            Status="In-Active"
                        }).ToList();

            foreach (var report in data)
            {
                if (report.SignOut == "0001-01-01 00:00:00.0000000")
                {
                    report.Status = "Active";

                }
            }
            return data;

            
        }
    }
}
