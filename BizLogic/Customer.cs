using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Transactions;

namespace BizLogic
{
    public class Customer : RegisterUser
    {
        private string FullName { get; set; }
        private string Email { get; set; }
        //private string Password { get; set; }
        public List<Account> CustomerAccounts { get; set; }
        private string _CustID { get; set; }
        //public string CustomerAccounts { get; set; }


        public Customer()
        {
            
        }

        public Customer(string fullName, string email, string password, int accType, string custID)
        {
            FullName = fullName;
            Email = email;
            //Password = password;
            _CustID = custID;
            //var account = new Account(accType, _CustID);
            //CustomerAccounts = new List<Account>();
            //CustomerAccounts.Add(account);
        }

        public void CreateNewAccount(int accountType )
        {
            //var account = new Account(accountType, _CustID);
            //CustomerAccounts.Add(account);
        }

        public decimal CheckBalance(string accountNumber)
        {
            decimal balance = 0;
            foreach (var account in CustomerAccounts)
            {
                if (account.AccountNumber.Equals(accountNumber))
                {
                    balance = account.Balance;
                    break;
                }
                else
                    balance = -1;
            }

            return balance;
        }

        public bool Deposit(string creditAccountNumber, decimal amount)
        {
            foreach (var account in CustomerAccounts)
            {
                if (account.AccountNumber.Equals(creditAccountNumber))
                {
                    account.Credit(amount);
                    var transaction = new Transaction("credit", DateTime.Now, amount);
                    account.TransactionHistory.Add(transaction);
                    return true;


                }
            }

            return false;
        }

        public bool Withdraw(string debitAccount, decimal amt)
        {
            foreach (var account in CustomerAccounts)
            {
                if (account.AccountNumber.Equals(debitAccount))
                {
                    if (account.Balance > amt)
                    {
                        account.Debit(amt);
                        var transaction = new Transaction("debit", DateTime.Now, amt);
                        account.TransactionHistory.Add(transaction);
                        return true;
                    }

                } 
            }

            return false;
        }

        //ask the SA for help here method is not efficient
        public bool Transfer(string debitAccount, string creditAccount, decimal amt)
        {

            Account getDebitAccount = null;
            Account getCreditAccount = null;

            foreach (var item in Customers)
            {
             
                foreach (var acct in item.CustomerAccounts)
                {
                    if (acct.AccountNumber.Equals(debitAccount))
                        getDebitAccount = acct;
                    else if(acct.AccountNumber.Equals(creditAccount))
                        getCreditAccount = acct;
                }
            }

            if(getCreditAccount != null && getDebitAccount != null)
            {
                if (getDebitAccount.Balance > amt)
                {
                    //debit
                    var debitTransaction = new Transaction(debitAccount, DateTime.Now, amt);
                    getDebitAccount.Debit(amt);
                    getDebitAccount.TransactionHistory.Add(debitTransaction);


                    //credit
                    var creditTransaction  = new Transaction(creditAccount, DateTime.Now, amt);
                    getCreditAccount.Credit(amt);
                    getCreditAccount.TransactionHistory.Add(creditTransaction);
                }

                return true;

            } 

            return false;
        }

        public List<Transaction> GetStatement(string accountNumber)
        {
            foreach (var account in CustomerAccounts)
            {
                if (account.AccountNumber.Equals(accountNumber))
                {
                    return account.TransactionHistory;
                }
            }

            return new List<Transaction>();
        }

        public List<Account> GetAccountsDetails()
        {
            return CustomerAccounts;
        }


    }

}
