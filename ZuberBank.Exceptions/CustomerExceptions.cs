using System;

namespace ZuberBank.Exceptions
{
    /// <summary>
    /// Exception class that represents any error raised in customer class 
    /// </summary>
    public class CustomerExceptions : ApplicationException
    {
        /// <summary>
        /// Constructor that initializes exception message
        /// </summary>
        
        public CustomerExceptions(string meassage):base(meassage) 
        { 
        
        }

        /// <summary>
        /// Constructor that initializes exception message and inner exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="Innerexception">Inner Exception</param>
        public CustomerExceptions(string message, Exception Innerexception): base(message, Innerexception) 
        {

        }


    }
}
