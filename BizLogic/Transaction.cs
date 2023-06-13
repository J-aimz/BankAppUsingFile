using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic
{
    enum Type
    {
        debit, credit
    }
    public class Transaction
    {
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }


        
        public Transaction(string transactionType, DateTime time, decimal amount)
        {
            TransactionType = transactionType;
            Amount = amount;
            Time = time;
        }



    }
}
