using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuberBank.Entities.Contracts
{
    /// <summary>
    /// Represents the Customer of the entity
    /// </summary>
    public interface ICustomer
    {
        #region Properties
        Guid CustomerID { get; set; }

        long CustomerCode {  get; set; }

        string CustomerName { get; set; }

        string Address {  get; set; }

        string Landmark { get; set; }

        string City { get; set; }

        string Country { get; set; }

        string Mobile { get; set; }
        #endregion


    }
}
