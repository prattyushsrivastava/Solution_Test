using BusinessLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestTempBadge.NewFolder
{
    public class Test
    {
        private readonly Mock<IGenricRepository> repoTest;

        public Test()
        {
            repoTest = new Mock<IGenricRepository>();


        }
        public List<Guard> getGuardData()
        {
            List<Guard> guards = new List<Guard>
            {
                new Guard
                {
                    Id = 0,
                    FirstName = "fname",
                    LastName = "lname",
                    EmpCode = 101,
                    SignIn = DateTime.Now,
                    TemporaryBadge = null,
                },

                new Guard
                {
                    Id = 1,
                    FirstName = "Prattyush",
                    LastName = "Srivastava",
                    EmpCode = 102,
                    SignIn = DateTime.Now,
                    TemporaryBadge = "waF?kxU7E%5U",
                },
                new Guard
                {
                    Id = 1,
                    FirstName = "Priya",
                    LastName = null,
                    EmpCode = 103,
                    SignIn = DateTime.Now,
                    TemporaryBadge = "QaF?kx5yE%5U",
                },
                new Guard
                {
                    Id = 1,
                    FirstName = "Aman",
                    LastName = "Singh",
                    EmpCode = 104,
                    SignIn = DateTime.Now,
                    TemporaryBadge = "QaF?kx5yE%5U",
                },
            };
            return guards;
        }

        [Fact]
        public void SignInBadge_STest()
        {
            var f = getGuardData();

            repoTest.Setup(x => x.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode)).Returns(f);

            var test = new GuardService(repoTest.Object);

            var result = test.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode);

            Assert.NotNull(result);


        }

        [Fact]

        public void SignInBadge_FTest()
        {
            var f = getGuardData();

            repoTest.Setup(x => x.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode)).Returns(f);

            var test = new GuardService(repoTest.Object);

            var result = test.SignInBadge(null, f[0].LastName, 2);

            Assert.Null(result);
        }

        [Fact]
        public void SignOutBadge_FTest()
        {
            var f = getGuardData();

            repoTest.Setup(x => x.SignOutBadge(f[0].Id)).Returns(f);

            var test = new GuardService(repoTest.Object);

            var result = test.SignOutBadge(f[0].Id);

            Assert.Null(result);
        }

        [Fact]
        public void SignOutPage_FTest()
        {
            var f = getGuardData();

            repoTest.Setup(x => x.SignOutPage(f[0].TemporaryBadge)).Returns(f);

            var test = new GuardService(repoTest.Object);

            var result = test.SignOutPage(f[0].TemporaryBadge);

            Assert.Null(result);
        }
    }
}
