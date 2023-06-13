using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic.Test
{
    [TestFixture]
    public class ValidationsTest
    {
        private Validations _validation;
        private static Customer _customer;
        private static RegisterUser _registerUser;

        [SetUp]
        public void Setup()
        {
            _validation = new Validations();
            //_customer = new Customer("James Adah", "a@mail.com", "#aaaaaa", 0);
            _registerUser = new RegisterUser();
            _registerUser.RegisterCustomers("James", "a@mail.com", "#aaaaaa", 0);



        }
        [Test]
        [TestCase("2", 3, true)]
        [TestCase("3", 4, true)]
        [TestCase("a", 5, false)]
        public void ChoiceChkTest(string input, int maxSelection, bool expected)
        {

            bool actual = _validation.ChoiceChk(input, maxSelection);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase("2James", false)]
        [TestCase("James", true)]
        [TestCase("2James", false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("6464", false)]

        public void FulNameChkTest(string input, bool expected)
        {
            bool actual = _validation.FulNameChk(input);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(" a@mail", false)]
        [TestCase(" a@mail", false)]
        [TestCase(" amail.dev", false)]
        [TestCase(" a@mail.dev", true)]
        public void EmailChk(string email, bool expected)
        {
            bool actual = _validation.EmailChk(email);

            Assert.AreEqual(expected, actual);
        }




        [Test]
        [TestCase("password", false)]
        [TestCase("Password", false)]
        [TestCase("#pass", false)]
        [TestCase("#111", false)]
        [TestCase("#password", true)]
        public void PasswordChkTest(string password, bool expected)
        {
            bool actual = _validation.PasswordChk(password);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("0", true)]
        [TestCase("1", true)]
        [TestCase("2", false)]
        [TestCase("-1", false)]
        [TestCase("one", false)]
        public void AccountTypeChkTest(string accountType, bool expected)
        {
            bool actual = _validation.AccountTypeChk(accountType);

            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //[TestCase()]
        //public void ValidatePersonalAccountNumberTest(List<Account> customerAccount, string accountNumber)
        //{
        //    bool actual = _validation.ValidatePersonalAccountNumber()
        //}

        //[Test]
        //[TestCase(_registerUser.Customers[0], "22222222222", false)]
        //public void VerifyAccountNumber(Customer customer, string accNumber, bool expected)
        //{
        //    _registerUser.RegisterCustomers("James", "a@mail.com", "#aaaaaa", 0);

           

        //    //string accNum = registerUser.Customers[0].CustomerAccounts[0].AccountNumber;
        //    bool actual = _validation.VerifyAccountNumber(customer, accNumber);

        //    Assert.AreEqual(expected, actual);
        //}

    }
}
