
using Microsoft.EntityFrameworkCore;
using Raven.Client.Exceptions;
using SendGrid.Helpers.Errors.Model;

namespace EmployeeManagementSystem.Exceptions
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (exception)
            {
                case InvalidOperationException ioException:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    await response.WriteAsJsonAsync(new { errorMessage = ioException.Message });
                    break;

                case ConflictException cException:
                    response.StatusCode = StatusCodes.Status409Conflict;
                    await response.WriteAsJsonAsync(new { error = cException.Message });
                    break;

                case DbUpdateException dbException:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    await response.WriteAsJsonAsync(new { error = dbException.Message });
                    break;

                case OperationCanceledException ocException:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    await response.WriteAsJsonAsync(new { error = ocException.Message });
                    break;

                case ForbiddenException fbException:
                    response.StatusCode = StatusCodes.Status403Forbidden;
                    await response.WriteAsJsonAsync(new { error = fbException.Message });
                    break;

                case UnauthorizedException uaException:
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    await response.WriteAsJsonAsync(new { error = uaException.Message });
                    break;

                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    await response.WriteAsJsonAsync(new { error = "An Unexcepted error occured" });
                    break;
            }
        }
    }
}
