namespace BizLogic;

public class Views
{
    public void RenderView(string message)
    {
        Console.WriteLine(message);
    }

    public string GetInput()
    {
        string input = Console.ReadLine();
        return input;
    }

    public void FirstScreen()
    {
        Console.Clear();
        RenderView("********* Welcome to BankY *********");
        RenderView("");
        RenderView("");
        RenderView(">>> 0 : Setup Account");
        RenderView(">>> 1 : Login");
        RenderView(">>> 2 : Exist Program");
        RenderView("");
        RenderView("Select Option: ");

    }

    public void AppView()
    {
        RenderView("********* Welcome to BankY *********");

        RenderView(">>> 0 -Setup Account");
        RenderView(">>> 1 -Check Balance");
        RenderView(">>> 2 -Deposit");
        RenderView(">>> 3 -Withdraw");
        RenderView(">>> 4 -Account Details");
        RenderView(">>> 5 -Account Statement");
        RenderView(">>> 6 -Transfer");
        RenderView(">>> 7 -Logout");
        RenderView("");
    }

    public void PrintAccountBalance(string[] printable)
    {

        RenderView("|-------------------------- | ------------------------ | --------------------- |");
        RenderView("|      ACCOUNT NAME         |     ACCOUNT NUMBER       |        BALANCE        |");
        RenderView("|-------------------------- | ------------------------ | ----------------------|");
        RenderView($"| {printable[0],-25} | {printable[1], 25} | {printable[2], -25}");
        RenderView("--------------------------------------------------------------------------------------------");

        Console.ReadKey();

    }

    public void AccountDetails(List<Account> accountList, string fullName)
    {
        RenderView($"Account Name: {fullName}");
        RenderView("|-------------------------- | ------------------------ | --------------------- |");
        RenderView("|      ACCOUNT Type         |     ACCOUNT NUMBER       |        BALANCE        |");
        RenderView("|-------------------------- | ------------------------ | ----------------------|");
        foreach (var account in accountList)
        {
            RenderView($"| {account.AccountType,-25} | {account.AccountNumber,-20} | {account.Balance,10}");
            RenderView("--------------------------------------------------------------------------------------------");
        }

        Console.ReadKey();
    }

    public void PrintAccountStatement(List<Transaction> accountStatement, string fullName, string accountNumber)
    {
        RenderView($"Account Name: {fullName}");
        RenderView($"Account Number: {accountNumber}");
        RenderView("|-------------------------- | ------------------------ | --------------------- |");
        RenderView("|      TRANSACTION TYPE         |     AMOUNT       |        DATE        |");
        RenderView("|-------------------------- | ------------------------ | ----------------------|");
        foreach (var transaction in accountStatement)
        {
            RenderView($"| {transaction.TransactionType, -10} | {transaction.Amount, -10} | {transaction.Time.ToString("dddd, dd MMMM yyyy hh: mm tt"), +10} |");
        }

        Console.ReadKey();
    }



}
