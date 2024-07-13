using ECommerceAPI.Api.Validation.FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceAPI.Api.Aspects
{
    public class ValidationFilter : Attribute, IAsyncActionFilter
    {
        private readonly Type _validationType;

        public ValidationFilter(Type validationType)
        {
            _validationType = validationType;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ValidationHelper.Validate(_validationType, context.ActionArguments.Values.ToArray());
            await next();
        }
    }
}
