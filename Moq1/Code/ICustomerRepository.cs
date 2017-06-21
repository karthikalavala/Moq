using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq1.Code
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
    }
}
