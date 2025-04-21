using System;
using System.Collections.Generic;
using ZuberBank.BusinessLogicLayer.BALContracts;
using ZuberBank.DataAccessLayer;
using ZuberBank.DataAccessLayer.DALContracts;
using ZuberBank.Entities;
using ZuberBank.Entities.Contracts;
using ZuberBank.Exceptions;

namespace ZuberBank.BusinessLogicLayer
{
    /// <summary>
    /// Represents Customers business logic
    /// </summary>
    public class CustomersBusinessLogicLayer : ICustomerBusinessLogicLayer
    {
        #region Private Fields
        private ICustomersDataAccessLayer _customersDataAccessLayer;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor That initializes CustomersDataAccessLayer
        /// </summary>
        public CustomersBusinessLogicLayer()
        {
            _customersDataAccessLayer = new CustomersDataAccessLayer();
        }
        #endregion

        #region Properties
        /// <summary>
        /// private property that represents reference of CustomersDataAccessLayer
        /// </summary>
        private ICustomersDataAccessLayer CustomersDataAccessLayer
        {
            set => _customersDataAccessLayer = value;
            get => _customersDataAccessLayer;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>List Of Customers</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                //invoke DAL
                return CustomersDataAccessLayer.GetCustomers();
            }
            catch (CustomerExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda Expression that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                //invoke DAL
                return CustomersDataAccessLayer.GetCustomersByCondition(predicate);
            }
            catch (CustomerExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// adds a new customer to the existing customer list
        /// </summary>
        /// <param name="customer">the customer object to add</param>
        /// <returns>Returns true, that indicates the customer is added successfully</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //get all customers
                List<Customer> allcustomers = CustomersDataAccessLayer.GetCustomers();

                long maxCustcode = 0;

                foreach (var item in allcustomers)
                {
                    if (item.CustomerCode > maxCustcode)
                    {
                        maxCustcode = item.CustomerCode;
                    }

                }
                //generate new customer number

                if (allcustomers.Count >= 1)
                {
                    customer.CustomerCode = maxCustcode + 1;
                }
                else
                {
                    customer.CustomerCode = ZuberBank.Configuration.Settings.BaseCustomerNumber + 1;
                }
                
                //invoke DAL
                return CustomersDataAccessLayer.AddCustomer(customer);
            }
            catch (CustomerExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// updates an existing customer
        /// </summary>
        /// <param name="customer">customer object that contains customer details to update</param>
        /// <returns>Returns true, that indicates the customer is updated</returns>

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //invoke DAL
                return CustomersDataAccessLayer.UpdateCustomer(customer);
            }
            catch (CustomerExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete an existing customer
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns>returns true, that indicates the customer is deleted</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                //invoke DAL
                return CustomersDataAccessLayer.DeleteCustomer(customerId);
            }
            catch (CustomerExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
