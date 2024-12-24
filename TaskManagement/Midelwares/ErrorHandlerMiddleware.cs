using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Wrappers;

namespace TaskManagement.Midelwares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new APIResponse<string>() { Succeed = false, Message = error?.Message };

                switch (error)
                {
                    case APIException e:
                        // Custome Application Exception 
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case DbUpdateException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = new List<string>();
                        responseModel.Errors.Add(error.Message);
                        responseModel.Errors.Add(error.InnerException?.Message);
                        break;
                    case ValidationException e:
                        // Custom Application Exception
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        //responseModel.Errors = e.er
                        break;
                    default:
                        // unhandled Error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
