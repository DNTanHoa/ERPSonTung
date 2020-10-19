using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace ERP.Helpers
{
    public class ApiValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string message = string.Join("; ", context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

                var response= new CommonResponeModel();

                response.Result=new ErrorResult(ActionType.Insert, message);

                context.Result = new OkObjectResult(response);
            }

            base.OnActionExecuting(context);
        }
    }
}