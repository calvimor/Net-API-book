using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Exceptions
{
    public class BusinessRuleException: Exception
    {
        public BusinessRuleException(string message) : base(message) { }
    }
}
