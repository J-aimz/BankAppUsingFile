using System.Linq;

namespace BizLogic;

public class Validations
{
    public int ChoiceSelection()
    {
        return 1;
    }

    public bool ChoiceChk(string input, int maxSelection)
    {
        int inputValue = 0;
        if(string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
           return false;
        if( !int.TryParse(input, out inputValue) || inputValue > maxSelection || inputValue < 0 || input.Length > 1 )
            return false;
       
        return true;
    }

    public bool FulNameChk(string inputName)
    {
        if(string.IsNullOrWhiteSpace(inputName.Trim()) || string.IsNullOrWhiteSpace(inputName.Trim())) 
            return false;
        if (((int)inputName[0] >= 97 && (int)inputName[0] <= 122 || ((int)inputName[0] >= 48 && (int)inputName[0] <= 57)))
            return false;

        return true;
    }

    public bool EmailChk(string inputEmail)
    {
        if(string.IsNullOrWhiteSpace(inputEmail.Trim()) || string.IsNullOrEmpty(inputEmail.Trim()) || !inputEmail.Contains("@") || !inputEmail.Contains(".") || inputEmail.Contains(","))
            return false;

        return true;
    }

    public bool PasswordChk(string inputPassword)
    {
        bool passwordIsValid = false;
        string[] specailCharacters = { "@", "#", "$", "%", "^", "&", "!" };
        
        foreach (var character in specailCharacters)
        {
            if (inputPassword.Contains(character))
                passwordIsValid = true;
        }
        if (string.IsNullOrWhiteSpace(inputPassword) || string.IsNullOrEmpty(inputPassword))
            passwordIsValid = false;
        if (inputPassword.Length < 6)
            passwordIsValid = false;

        

        return passwordIsValid;

    }

    public bool AccountTypeChk(string accType)
    {
        int type = 0;
        if(!int.TryParse(accType, out type) || type < 0 || type > 1)
            return false;
        return true;
    }

    public string[] ValidatePersonalAccountNumber(List<string[]> customerAccounts, string accNumber)
    {
        bool isvalid = false;
        foreach (var account in customerAccounts)
        {
            if (account[1].Equals(accNumber))
                return account;
        }

        return null;
    }

    public bool VerifyPersonalAccountNumber(Customer customer, string accNumber)
    {
        foreach (var account in customer.CustomerAccounts)
        {
            if (account.AccountNumber.Equals(accNumber))
            {
                return true;
            }
        }
        return false;
    }

    public bool VerifyAmount(string amount)
    {
        decimal amt = 0;
        
        if(!decimal.TryParse(amount, out amt) || amt < 1)
            return false;

        return true;
    }



    

}
