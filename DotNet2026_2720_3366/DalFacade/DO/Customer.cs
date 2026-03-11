using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Customer(int CustomerId, string CustomerName, string? Address, string? PhoneNumber)
    {
        public Customer() : this(0, "", "", "")
        {

        }

    
    }
}
