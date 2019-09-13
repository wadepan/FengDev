using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMe.Domain.Entities
{
    public partial class Renter
    {
       

        public string FullName
        {
            get { return this.FirstName + " "+ this.LastName; }
           
        }
        
    }
}
