using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Exceptions
{
    public class MismatchedReturnTypeException : System.Exception
    {
        public MismatchedReturnTypeException(Type attemptedType, string givenJson, Exception e) : base(
            "Unable to convert to type T::" + givenJson, e)
        {
            
        }
    }
}
