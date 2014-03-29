using System;
using System.Text;
using System.Collections.Generic;
using BankAccountClasses;


class BankAccountVariableTypes
{
    static void Main()
    {     
        List<Card> cardsList = new List<Card>();

        Console.WriteLine("Please, enter holder's first name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Please, enter holder's middle name:");
        string middleName = Console.ReadLine();
        Console.WriteLine("Please, enter holder's last name:");
        string lastName = Console.ReadLine();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter credit card {0} number: ", i + 1);
            string cardNumber = Console.ReadLine();
            Card newCard = new Card(cardNumber);
            cardsList.Add(newCard);
        }


        Holder newHolder = new Holder(firstName, middleName, lastName);

        BankAccount newBankAccount = new BankAccount(newHolder, 234, "STSA930012002");
        newBankAccount.CardsList = cardsList;

        Console.WriteLine("Bank Account details:\n");
        Console.WriteLine("Holder's first name: {0}", newBankAccount.AccountHolder.FirstName);
        Console.WriteLine("Holder's middle name: {0}", newBankAccount.AccountHolder.MiddleName);
        Console.WriteLine("Holder's last name: {0}", newBankAccount.AccountHolder.LastName);
        Console.WriteLine("IBAN: {0}", newBankAccount.IBAN);
        Console.WriteLine("BIC: {0}", Bank.bic);
        Console.WriteLine("Bank Name: {0}", Bank.bankName);
        Console.WriteLine("Balance: {0} euro", newBankAccount.Balance);
        Console.WriteLine("Bank Card Numbers: ");

        for (int m = 0; m < newBankAccount.CardsList.Count; m++)
        {
            Console.WriteLine(newBankAccount.CardsList[m].CardNumber);
        }

    }
}

