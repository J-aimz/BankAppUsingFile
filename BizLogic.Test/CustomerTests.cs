using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic.Test
{
    [TestFixture]
    public class CustomerTests
    {
        private RegisterUser _allCustomers;
        private Customer _customer;
        public string acctNum;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
            _allCustomers = new RegisterUser();
            _allCustomers.RegisterCustomers("James", "a@mail.com", "111111", 0);
            acctNum = _allCustomers.Customers[0].CustomerAccounts[0].AccountNumber;
        }

        //[Test]
        //[TestCase("2222222222", -1)]
        //[TestCase(acctNum, 0)]
        //public void CheckBalanceTest(string accountNumber, decimal expected)
        //{
        //    decimal actual = _customer.CheckBalance(accountNumber);

        //    Assert.AreEqual(expected, actual);
        //    }
        //}
    }
}
