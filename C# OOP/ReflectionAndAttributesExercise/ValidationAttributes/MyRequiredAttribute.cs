using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {

        public override bool IsValid(object obj)
      => obj is not null;
    
    }
}
