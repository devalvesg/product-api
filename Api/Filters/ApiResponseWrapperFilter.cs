using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class ApiResponseWrapperFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var status = objectResult.StatusCode ?? 200;
                var wrapped = new
                {
                    result = objectResult.Value,
                    code = status,
                    error = (object)null
                };
                context.Result = new ObjectResult(wrapped)
                {
                    StatusCode = status
                };
            }
        }
    }
}
