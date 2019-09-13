using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMe.Domain.Enums
{
    public enum BusinessObject : int
    {
       Activity = 1,
       Issue = 2, 
       Renter = 3,
       Lease = 4, 
       LeaseDoc = 5
    }
}
