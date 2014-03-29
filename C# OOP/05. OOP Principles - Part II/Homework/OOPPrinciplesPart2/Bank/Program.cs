using System;

namespace Bank
{
    class Program
    {
        static void Main()
        {

            //create new bank
            Bank bank = new Bank();

            //create customer of type Indivual with name John Doe
            Individual ind = new Individual("John", "Doe");

            Console.WriteLine("Customer of type {0} with name {1} {2} created", 
                ind.GetType(), ind.FirstName, ind.LastName);

            //adds customer to the bank
            bank.AddCustomer(ind);
           
            //creates deposit account for customer with starting money 500 euro 
            ind.AddAccount(new DepositAccount(500));

            //deposits 9500 euro into the deposit account (account 0 in the list)
            ind.DepositMoney(0, 9500);


            Console.WriteLine("Display customer's {0} balance: {1} euro", bank.Customers[0].Accounts[0].GetType(), 
                bank.Customers[0].Accounts[0].Balance);

            int months = 10;
            Console.WriteLine("Interest for {0} months: {1} euro", months, bank.Customers[0].Accounts[0].CalculateInterest(months));

            decimal withdrawAmount = 100;
            Console.WriteLine("Withdrawing {0} euro...", withdrawAmount);

            ind.Accounts[0].WithdrawMoney(withdrawAmount);

            Console.WriteLine("Current balance: {0}", bank.Customers[0].Accounts[0].Balance);

            Console.WriteLine("Creating new Loan account for customer with balance 1000 euro");
            ind.AddAccount(new LoanAccount(1000));


            Console.WriteLine("Display {0} Balance: {1}", 
                bank.Customers[0].Accounts[1].GetType(), bank.Customers[0].Accounts[1].Balance);

            months = 10;
            Console.WriteLine("Interest for {0} months: {1} euro", months, bank.Customers[0].Accounts[1].CalculateInterest(months));

            Console.WriteLine("Creating new customer (company): Biomet, Bulstat: 1234, start balance: 1000 euro ...");
            Company comp = new Company("Biomet", "1234", new LoanAccount(1000));

            Console.WriteLine("Adding the company customer to the bank...");
            bank.AddCustomer(comp);

            months = 10;
            Console.WriteLine("Biomet Loan Account Interest for {0} months: {1} euro", months, 
                bank.Customers[1].Accounts[0].CalculateInterest(months));
           
        }
    }
}
