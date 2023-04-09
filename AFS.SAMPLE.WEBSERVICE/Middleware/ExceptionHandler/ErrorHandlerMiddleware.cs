
using AFS.SAMPLE.ApplicationLayer.ExceptionLogs;
using AFS.SAMPLE.DomainModelLayer.ExceptionLogs;
using AFS.SAMPLE.ViewModels;
using System.Net;
using System.Text.Json;

namespace AFS.SAMPLE.WEBSERVICE.Middleware.ExceptionHandler
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IExceptionLogService _exceptionLogService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var exp = new ExceptionLog()
                {
                    InnerStackTrace = error.InnerException != null ? error.InnerException.StackTrace.ToString() : string.Empty,
                    StackTrace = error.StackTrace != null ? error.StackTrace : string.Empty
                };

                var errorStr = string.Empty;
                switch (error)
                {
                    case DynamicException e:
                        // custom application error
                        exp.StatusCode = HttpStatusCode.BadRequest;
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorStr = e.Message;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        exp.StatusCode = HttpStatusCode.NotFound;
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorStr = e.Message;
                        break;

                    default:
                        // unhandled error
                        exp.StatusCode = HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorStr = "Server Error, Please contact support team.";//todo
                        break;
                }

                await _exceptionLogService.AddAsync(exp);
                var result = JsonSerializer.Serialize(new ErrorResponse(error?.Message));
                await response.WriteAsync(result);

            }
        }
    }
}
