using System;
using ZuberBank.Entities.Contracts;
using ZuberBank.Exceptions;

namespace ZuberBank.Entities
{
    /// <summary>
    /// Represents the customer of the bank
    /// </summary>
    public class Customer : ICustomer
    {
        #region Private Fields
        private Guid _customerID;
        private long _customerCode;
        private string _customerName;
        private string _address;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;
        #endregion

        #region Public Properties
        public Guid CustomerID { get => _customerID; set => _customerID = value; }
        public long CustomerCode 
        { 
            get => _customerCode; 
            set
            {
                if (value>0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerExceptions("Customer Code should Be Positive Only");
                }
            }
        }
        public string CustomerName 
        { 
            get => _customerName;
            set
            {
                //customer name should be less than 40 characters
                if (value.Length <= 40 && string.IsNullOrEmpty(value))
                {
                   _customerName = value;  
                }
                else
                {
                    throw new CustomerExceptions("Customer Name Should not be null and less than 40 Characters long");
                }
            }
        }
        public string Address { get => _address; set => _address = value; }
        public string Landmark { get => _landmark; set => _landmark = value; }
        public string City { get => _city; set => _city = value; }
        public string Country { get => _country; set => _country = value; }
        public string Mobile 
        { 
            get => _mobile;
            set
            {
                //mobile number should be 10 digit mobile number
                if (value.Length == 10)
                {
                    _mobile = value;
                }
                else
                {
                    throw new CustomerExceptions("Mobile Number Should be 10 digit Mobile number");
                }
            }
        }
        #endregion
    }
}
