using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Core.Dto.Registration.Request
{
    public class EmailAddressDTO
    {
        public string Email { get; set; }
        public int EmailPromotion { get; set; }
    }
}
