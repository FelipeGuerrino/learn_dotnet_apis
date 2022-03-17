using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using src.Models.Users;

namespace src.Filters
{
    public class ValidateCustomModelState : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(!context.ModelState.IsValid) 
            { 
                var validateFieldViewModel = new ValidateFieldViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage ));
                context.Result = new BadRequestObjectResult(validateFieldViewModel);
            }
        }

    }
}