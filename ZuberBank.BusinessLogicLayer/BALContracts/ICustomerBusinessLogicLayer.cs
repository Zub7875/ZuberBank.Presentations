using System;
using System.Collections.Generic;
using ZuberBank.Entities;

namespace ZuberBank.BusinessLogicLayer.BALContracts
{
    public interface ICustomerBusinessLogicLayer
    {
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>List Of Customers</returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda Expression that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);

        /// <summary>
        /// adds a new customer to the existing customer list
        /// </summary>
        /// <param name="customer">the customer object to add</param>
        /// <returns>Returns true, that indicates the customer is added successfully</returns>
        Guid AddCustomer(Customer customer);

        /// <summary>
        /// updates an existing customer
        /// </summary>
        /// <param name="customer">customer object that contains customer details to update</param>
        /// <returns>Returns true, that indicates the customer is updated</returns>
        bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Delete an existing customer
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns>returns true, that indicates the customer is deleted</returns>
        bool DeleteCustomer(Guid customerId);
    }
}
