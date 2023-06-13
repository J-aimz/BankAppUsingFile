using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic
{
    public enum AccType
    {
        saving = 0, current = 1
    }
    public class Account
    {
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public AccType AccountType { get; set; }
        public  List<Transaction> TransactionHistory { get; set; }
        private string _CustID { get; set; }
        // public Customer Customer { get; set; }


        //public Account(int accountType, string custID, decimal balance = 0)
        //{
        //    this.Balance = balance;
        //    this.AccountType = (AccType)accountType;
        //    this.AccountNumber = GenerateAccountNumber();
        //    this.TransactionHistory = new List<Transaction>();

        //    _CustID= custID;


        //}

        public void Credit(decimal amount)
        {
            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            Balance -= amount;
        }

        //generate account number
        public string GenerateAccountNumber()
        {
            string accNum = "";
            var randomNumber = new Random();
            while (accNum.Length < 10)
            {
                if(accNum.Length == 0)
                    accNum = "0";
                else
                    accNum += randomNumber.Next(0,9);
            }

            return accNum;
        }


    }
}
