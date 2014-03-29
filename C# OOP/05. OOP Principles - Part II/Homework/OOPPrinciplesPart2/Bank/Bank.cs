using System;
using System.Collections.Generic;

namespace Bank
{
    /// <summary>
    /// A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. Customers could be                individuals or companies.
    /// </summary>
    public class Bank
    {
        private List<Customer> customers = new List<Customer>();

        public Bank(List<Customer> customers)
        {
            this.Customers = customers;
            
        }
        public Bank()
        {
        }

        public List<Customer> Customers
        {
            get 
            { 
                return customers; 
            }
            set 
            { 
                customers = value; 
            }
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }
    }
}
