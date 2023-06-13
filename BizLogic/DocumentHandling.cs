using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic
{
    enum AccountType
    {
        saving, current
    }
    public class DocumentHandling
    {
        private Account _account;

        public DocumentHandling()
        {
            _account = new Account();
        }



        public void RegisterNewCustomer(string fullName, string email, string password, int accChoice)
        {
            string pathToCustomerFile = "C:\\Users\\JAIMZ\\Desktop\\DECAGON_CODE\\WEEK_FIVE\\week_task\\BizLogic\\data\\customers.txt";

            //generating customer Id
            string custID = Guid.NewGuid().ToString().Split("-")[0];  
            string content = $"{custID},{fullName},{email},{password}";

            //register new user
            File.AppendAllText(pathToCustomerFile, content);

            //chk back here when it comes to making multiple accounts bcos im making another account by user later i want to be sure that the account is still signed t the same user

            //register new account number on the account doc
            string pathToAccounts = "C:\\Users\\JAIMZ\\Desktop\\DECAGON_CODE\\WEEK_FIVE\\week_task\\BizLogic\\data\\Account.txt";

            //account creation
            string accountNumber = _account.GenerateAccountNumber();
            //custID,accountNumber,accounttype,balance
            File.AppendAllText(pathToAccounts, $"{custID},{accountNumber},{(AccountType)accChoice},0");

            //Dictionary<string, string> newCustormer = new()
            //{
            //    {"CustId", custID },
            //    {"fullName",fullName },
            //    {"email",email },
            //    {"password", password },
            //    {"accType", $"{(AccountType)accChoice}" },
            //    {"accountNumber", accountNumber},
            //};


            //return newCustormer;

        }

        public string[] RegisterNewAccount(string custID, int acctype)
        {
            string custPath = "C:\\Users\\JAIMZ\\Desktop\\DECAGON_CODE\\WEEK_FIVE\\week_task\\BizLogic\\data\\customers.txt";
            string accountNumber = _account.GenerateAccountNumber();
            string newAccount = $"{custID},{accountNumber},{(AccountType)acctype},0";

            File.AppendAllText(custID, newAccount);
            string[] accInfo = { accountNumber, "0" };
            return accInfo;


        }
    }
}
