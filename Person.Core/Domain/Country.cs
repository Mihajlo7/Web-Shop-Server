using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Person.Core.Domain
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string CountryRegionCode { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
