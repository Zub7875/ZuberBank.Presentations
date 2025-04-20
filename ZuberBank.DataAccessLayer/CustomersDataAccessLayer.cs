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


        #endregion
    }
}
