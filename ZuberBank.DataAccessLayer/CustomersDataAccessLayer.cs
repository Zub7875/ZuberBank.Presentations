using System;
using System.Collections.Generic;
using ZuberBank.Entities;
using ZuberBank.Exceptions;
using ZuberBank.DataAccessLayer.DALContracts;


namespace ZuberBank.DataAccessLayer
{
    /// <summary>
    /// Represents DAL for bank customers
    /// </summary>
    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        #region Fields
        private List<Customer> _customers;
        #endregion

        #region Constructors
        public CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents source customer collection
        /// </summary>
        private List<Customer> Customers
        {
            set => _customers = value;
            get => _customers;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Return all existing customers
        /// </summary>
        /// <returns>Customers list</returns>s
        public List<Customer> GetCustomers()
        {
            //create a new customer list
            List<Customer> customerslist = new List<Customer>();

            //copy all customers from source collection into the newcustomers list
            _customers.ForEach(item => customerslist.Add(item.Clone() as Customer));
            return customerslist;
        }

        /// <summary>
        /// Returns list of the customers that matching the criteria
        /// </summary>
        /// <param name="predicate">Lambda expression with condition</param>
        /// <returns>List of matching customers</returns>

        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            //create a new customer list
            List<Customer> customerlist = new List<Customer>();

            //filter the collection
            List<Customer> filteredCustomers = customerlist.FindAll(predicate);

            //copy all customers from the source collection into the new customerlist
            Customers.ForEach(item => filteredCustomers.Add(item.Clone() as Customer));

            return customerlist;
        }

        /// <summary>
        /// Add a new customer to exisying list
        /// </summary>
        /// <param name="customer">customer object to add</param>
        /// <returns>Returns Guid for newly created customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            //generate new Guid
            customer.CustomerID = Guid.NewGuid();

            Customers.Add(customer);

            return customer.CustomerID;
        }

        /// <summary>
        /// To Update the customer
        /// </summary>
        /// <param name="customer">Customer object to update</param>
        /// <returns>Updated customer Object</returns>
        public bool UpdateCustomer(Customer customer)
        {
            //find existing customer by customerId
            Customer existingcustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

            //update all details of customer
            if (existingcustomer != null)
            {
                existingcustomer.CustomerCode = customer.CustomerCode;
                existingcustomer.CustomerName = customer.CustomerName;
                existingcustomer.Address = customer.Address;
                existingcustomer.Landmark = customer.Landmark;
                existingcustomer.City = customer.City;
                existingcustomer.Country = customer.Country;
                existingcustomer.Mobile = customer.Mobile;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delets an existing customer based on CustomerID
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns>Indicates wether the customer is deleted or not</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            //delete customer by CustomerID
            if (Customers.RemoveAll(item => item.CustomerID == customerId) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion
    }
}
