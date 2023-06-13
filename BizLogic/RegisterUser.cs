using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic
{
    public class RegisterUser
    {
        public List<Customer> Customers = new List<Customer>();

        public Account RegisterCustomers(string fullName, string email, string password, int accType)
        {
            //document
            string custID = RegisterNewCustomerDocs(fullName, email, password, accType);

            //old app
            //var customer = new Customer(fullName, email, password, accType, custID);
            //Customers.Add(customer);
            //return customer.CustomerAccounts[customer.CustomerAccounts.Count - 1];

            Customer customer = new Customer(fullName, email, password, accType, custID);


            return customer;
        }

        public Account RegisterCustomersNewAccount(Customer customer, int accountType)
        {
            foreach (var eachCustomer in Customers)
            {
                if (eachCustomer.Equals(customer))
                {
                    eachCustomer.CreateNewAccount(accountType);
                }
            }

            return customer.CustomerAccounts[customer.CustomerAccounts.Count - 1];
        }

        public string RegisterNewCustomerDocs(string fullName, string email, string password, int accChoice)
        {
            string pathToCustomerFile = "C:\\Users\\JAIMZ\\Desktop\\DECAGON_CODE\\WEEK_FIVE\\week_task\\BizLogic\\data\\customers.txt";

            //generating customer Id
            string custID = Guid.NewGuid().ToString().Split("-")[0];
            string content = $"{custID},{fullName},{email},{password},{accChoice}";


            File.AppendAllText(pathToCustomerFile, content);

           

            return custID;
        }
    }
}
