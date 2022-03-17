using System.Collections.Generic;

namespace src.Models.Users
{
    ///
    public class ValidateFieldViewModelOutput
    {
       public IEnumerable<string> Errors { get; private set; }

        ///
       public ValidateFieldViewModelOutput(IEnumerable<string> errors)
       {
           Errors = errors;
       } 
    }
}