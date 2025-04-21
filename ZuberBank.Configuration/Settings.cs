using System;

namespace ZuberBank.Configuration
{
    /// <summary>
    /// Project Level Configuration Settings
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Customer Number Starts From 1001 and increment by 1;
        /// </summary>

        public static long BaseCustomerNumber { get; set; } = 1000;
    }
}
