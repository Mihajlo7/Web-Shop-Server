using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Person.Core.Domain
{
    public class BusinessEntityAdress : Entity
    {   
        public Guid? AddressId { get; set; }
        public virtual Address? Address { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}


