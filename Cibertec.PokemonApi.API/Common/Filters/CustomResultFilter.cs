using Cibertec.PokemonApi.Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cibertec.PokemonApi.API.Common.Filters
{
    public class CustomResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {

            if (context.Result is not EmptyResult)
            {

                var response = ((ObjectResult)context.Result).Value;
                int statusCode = default;

                if (response.GetType().GetGenericTypeDefinition() == typeof(SuccessResult<>))
                {
                    statusCode = 200;
                }
                else if (response.GetType().GetGenericTypeDefinition() == typeof(FailureResult<ValidationException>))
                {
                    statusCode = 400;
                }
                else if (response.GetType() == typeof(FailureResult<ValidationException>))
                {
                    statusCode = 400;
                }
                else if (response.GetType() == typeof(FailureResult<ConflictException>))
                {
                    statusCode = 409;
                }
                else if (response.GetType() == typeof(FailureResult<NoAutorizadoException>))
                {
                    statusCode = 403;
                }
                else
                {
                    statusCode = 500;
                }
                context.Result = new ObjectResult(response) { StatusCode = statusCode };
                await next();
            }
            else
            {
                context.Cancel = true;
            }

        }
    }
}
