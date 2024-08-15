using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Person.Core.Domain
{
    public class Password : Entity
    {
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
