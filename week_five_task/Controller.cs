using BizLogic;

namespace Bank_App;

public class Controller
{
    private  Views GetView;
    private Validations Validate;
    private RegisterUser Users;
    private DocumentHandling _DocumentHacddling;



    public Controller()
    {
        GetView = new Views();
        Validate = new Validations();
        Users = new RegisterUser();
        _DocumentHacddling = new DocumentHandling();
    }


    public  int FirstView()
    {
    jumpBack:
        int choice = 0;
        GetView.FirstScreen();
        string input = GetView.GetInput();

        bool validateChoice = Validate.ChoiceChk(input, 2);


        if (validateChoice)
            choice = int.Parse(input);
        else if (!validateChoice)
            goto jumpBack;

        return choice;
    }

    //setup an account
    public void SetupAccount()
    {
        Console.Clear();
        GetView.RenderView("********* Welcome to BankY *********");
        GetView.RenderView("");
        GetView.RenderView("");

    //get and validate name input
    name:
            GetView.RenderView("Enter Full Name: ");
            string fullName = GetView.GetInput();

            if (!Validate.FulNameChk(fullName))
            {
                GetView.RenderView("Invalid Format \"Cant start name with a number or lower case\" : ");
                GetView.RenderView("");

                goto name;
            }
            GetView.RenderView("");
            
            //get and validate email
        email:
            GetView.RenderView("Enter Email: ");
            string email = GetView.GetInput();

            if (!Validate.EmailChk(email))
            {
                GetView.RenderView("Invalid Format \"Email format : jane@doe.com\" : ");
                GetView.RenderView("");

                goto email;
            }
            GetView.RenderView("");

            //get and validate password
        password:
            GetView.RenderView("Enter Password: ");
            string password = GetView.GetInput();

            if (!Validate.PasswordChk(password))
            {
                GetView.RenderView("Invalid Format \"Password should be minimum 6 characters that include alphanumeric and at least one special characters (@, #, $, %, ^, &, !)\" : ");
                GetView.RenderView("");

                goto password;
            }
            GetView.RenderView("");

            //get and validate account type
        accountType:
            GetView.RenderView("Select Account Type /n >>> 0 -savings OR 1 -current: ");
            string accountType = GetView.GetInput();

            if (!Validate.AccountTypeChk(accountType))
            {
                GetView.RenderView("Invalid input enter: >>> \"0\" -savings OR \"1\" -current: ");
                GetView.RenderView("");
                goto accountType;
            }

            int accChoice = int.Parse(accountType);
            GetView.RenderView("");

            //old
            //initialise and register new customer 
            //var newUser = Users.RegisterCustomers(fullName, email, password, accChoice);


        //registering to the document
        _DocumentHacddling.RegisterNewCustomer(fullName, email, password, accChoice);

        /*
         
            come back here and maybe document handling would have wahat u want
         
         */

        GetView.RenderView($"Account Opened Successfully Here is Your Account Number: {newUser.AccountNumber} and your balance is: {newUser.Balance}");

            Console.ReadLine();

    }

    public void SetupAnotherAccount(string[] customer)
    {
        Console.Clear();
        GetView.RenderView("********* Welcome to BankY *********");
        GetView.RenderView("");
        GetView.RenderView("");

        accountType:

            GetView.RenderView("Select Account Type /n >>> 0 -savings OR 1 -current: ");
            string accountType = GetView.GetInput();

            if (!Validate.AccountTypeChk(accountType))
            {
                GetView.RenderView("Invalid input enter: >>> \"0\" -savings OR \"1\" -current: ");
                GetView.RenderView("");
                goto accountType;
            }

        int accChoice = int.Parse(accountType);
        GetView.RenderView("");


        //new setup new acctount 
        string[] accDetail = _DocumentHacddling.RegisterNewAccount(customer[0], accChoice);



        GetView.RenderView($"Account Opened Successfully Here is Your Account Number: {accDetail[0]} and your balance is: {accDetail[1]}");

        Console.ReadLine();

    }


    //chk for user if exist run main program 
    public void Login()
    {
        Console.Clear();
        GetView.RenderView("********* Welcome to BankY *********");
        GetView.RenderView("");
        GetView.RenderView("");

            //get and validate user name OR email
        userName:
            GetView.RenderView("Enter Full Name OR Email");
            string userName = GetView.GetInput();

            if (Validate.FulNameChk(userName) || Validate.EmailChk(userName))
            {
                GetView.RenderView("Enter password");
                string password = GetView.GetInput();


                //read data frm the file 
                string path = "C:\\Users\\JAIMZ\\Desktop\\DECAGON_CODE\\WEEK_FIVE\\week_task\\BizLogic\\data\\customers.txt";
                
                using (var sr = new StringReader(path))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(",");

                        if (data[1].Equals(userName) && data[2].Equals(password))
                        {
                            MainApp(data);
                            break;
                        }
                    }
                }
            }

            GetView.RenderView("Invalid \"NAME\" or \"EMAIL\"");
            GetView.RenderView("");
            goto userName;
            
    }

    public void MainApp(string[] customer)
    {
        bool logut = false;
        do
        {

            Console.Clear();
            
            
            jumpBack:

            //foreach (var item in Users.Customers)
            //{
            //    if (item.Equals(customer))
            //    {
            //        foreach (var inner in item.CustomerAccounts)
            //        {
            //            Console.WriteLine("account number" + inner.AccountNumber);
            //            Console.WriteLine("account number" + inner.AccountType);

            //            Console.WriteLine("");
                        
            //        }
            //    }
            //}


                GetView.AppView();
                GetView.RenderView($"Hi {customer[1].Split(" ")[0]}!");
                GetView.RenderView("Please Select a Service: ");
                string input = GetView.GetInput();
                if (!Validate.ChoiceChk(input, 7))
                {
                    GetView.RenderView("INVALID INPUT!!!!");
                    GetView.RenderView("");
                    Console.ReadKey();
                    goto jumpBack;
                }
                    

            int choice = int.Parse(input);

            //logout if user selection is 7
            if(choice == 7)
                logut = true;

            // call method according to user choice 
            SwitchSelection(customer, choice);

        } while (!logut);

    }

    //switch through user choice
    public void SwitchSelection(string[] customer, int choice)
    {
        switch (choice)
        {
            case 0:
                //chk this bcos the user is already logged in so the account should be assocaited with his account
                SetupAnotherAccount(customer);
                break;
            case 1:
                CheckBalance(customer);
                break;
            case 2:
                Deposit(customer);
                break;
            case 3:
                Withdraw(customer);
                break;
            case 4:
                GetAccountDetails(customer);
                break;
            case 5:
                GetAccountStatement(customer);
                break;
            case 6:
                MakeTransfer(customer);
                break;
            case 7:
                break;
        }
    }


    public void CheckBalance(string[] customer)
    {
        Console.Clear();
        GetView.RenderView($"********* Welcome to BankY ({customer[1]}) *********");
        GetView.RenderView("");
        GetView.RenderView("");
        GetView.RenderView("Input Account Number");
        string accountNumber = GetView.GetInput();



        //retriving customer account details
        var customerAccountDetails = _DocumentHacddling.GetAllUserAccountDetails(customer[0]);

        var accountDetail = Validate.ValidatePersonalAccountNumber(customerAccountDetails, accountNumber);
        if (accountDetail != null)
        {
            string[] printable = { customer[1], accountDetail[1], accountDetail[3] };
            GetView.PrintAccountBalance(printable);
        }
        else
        {
            GetView.RenderView("");
            GetView.RenderView("Invalid Account Number");

            Console.ReadKey();
        }

    }

    //here
    public void Deposit(string[] customer)
    {
        Console.Clear();
        GetView.RenderView($"********* Welcome to BankY ({customer[1]}) *********");

        GetView.RenderView("Enter Account Number: ");
        string account = GetView.GetInput();

        GetView.RenderView("Enter Amount: ");
        string amount = GetView.GetInput();



        if (Validate.VerifyAccountNumber(customer, account) && Validate.VerifyAmount(amount))
        {
            decimal amt = decimal.Parse(amount);
           

            //notification of successful transaction
            if (customer.Deposit(account, amt))
            {

                GetView.RenderView("");
                GetView.RenderView("Deposit Successful");

                Console.ReadKey();
            }
            else
            {
                GetView.RenderView("");
                GetView.RenderView("Something Went Wrong! Try Again");

                Console.ReadKey();
            }

        }
        else
        {
            GetView.RenderView("");
            GetView.RenderView("Invalid Account Number");

            Console.ReadKey();
        }
    }
    public void Withdraw(Customer customer)
    {
        Console.Clear();
        GetView.RenderView($"********* Welcome to BankY ({customer.FullName}) *********");

        GetView.RenderView("Enter Account Number: ");
        string account = GetView.GetInput();

        GetView.RenderView("Enter Amount: ");
        string amount = GetView.GetInput();

        if (Validate.VerifyAccountNumber(customer, account) && Validate.VerifyAmount(amount))
        {

            
            decimal amt = decimal.Parse(amount);

            //notification if transaction is successful 
            if (customer.Withdraw(account, amt))
            {
                GetView.RenderView("");
                GetView.RenderView("Withdraw Successful");

                Console.ReadKey();
            }
            else
            {
                GetView.RenderView("");
                GetView.RenderView("Insufficient Funds");

                Console.ReadKey();
            }
        }
        else
        {
            GetView.RenderView("");
            GetView.RenderView("Invalid Account Number");

            Console.ReadKey();
        }

    }

    public void GetAccountDetails(Customer customer)
    {
        Console.Clear();
        GetView.RenderView($"********* Welcome to BankY ({customer.FullName}) *********");

        var details = customer.GetAccountsDetails();
        GetView.AccountDetails(details, customer.FullName);
    }


    /*
     *
     *
     *run validations for the the account inputs in transfers
     *
     */
    public void MakeTransfer(Customer customer)
    {
        Console.Clear();
        GetView.RenderView($"********* Welcome to BankY ({customer.FullName}) *********");

        GetView.RenderView("Input Account To Debit: ");
        string debitAcct = GetView.GetInput();


        GetView.RenderView("Input Account To Credit: ");
        string creditAcct = GetView.GetInput();


        GetView.RenderView("Input Amount: ");
        decimal amt = decimal.Parse(GetView.GetInput());

        customer.Transfer(debitAccount: debitAcct, creditAccount: creditAcct, amt: amt);


    }

    public void GetAccountStatement(Customer customer)
    {
        Console.Clear();
        GetView.RenderView($"********* Welcome to BankY ({customer.FullName}) *********");

        GetView.RenderView("Enter Account Number: ");
        string accountNumber = GetView.GetInput();

        if (Validate.ValidatePersonalAccountNumber(customer.CustomerAccounts, accountNumber))
        {
            var accountStatement = customer.GetStatement(accountNumber);

            if (accountStatement != null)
            {
                GetView.PrintAccountStatement(accountStatement, customer.FullName, accountNumber);
            }
        }
      
    }


    public bool ExistApp()
    {
        return true;
    }
}
