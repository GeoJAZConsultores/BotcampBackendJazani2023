using System.Net;
using Jazani.Api.Exceptions;
using Jazani.Application.Cores.Exceptions;
using Newtonsoft.Json;

namespace Jazani.Api.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var errorResult = new ErrorModel();
                HttpStatusCode statusCode;


                switch (exception)
                {
                    case NotFoundCoreException e:
                        statusCode = HttpStatusCode.NotFound;
                        errorResult.Message = e.Message;
                        break;

                    default:
                        statusCode = HttpStatusCode.InternalServerError;
                        errorResult.Message = "Se ha producido un error inesperado";
                        break;
                }


                var response = context.Response;

                if(!response.HasStarted)
                {
                    response.ContentType = "application/json";
                    response.StatusCode = (int)statusCode;

                    await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
                }

            }
        }
    }
}

