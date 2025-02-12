using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;
using System.Text;
using System.Text.Json;

namespace S.P.WithCleanArchiteture.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next.Invoke(context);
            }
            catch (UserBaseException UserException)
            {
                await HandleExceptionAsync(UserException.Message, context, StatusCodes.Status404NotFound,UserException.StackTrace);
            }
            catch (OrderBaseException OrderException)
            {
                await HandleExceptionAsync(OrderException.Message, context, StatusCodes.Status404NotFound,OrderException.StackTrace);
            }
            catch (ProductBaseException ProductException)
            {
                await HandleExceptionAsync(ProductException.Message, context, StatusCodes.Status404NotFound,ProductException.StackTrace);
            }
            catch (ValidationBaseException InvalidDataFormatException)
            {
                await HandleExceptionAsync(InvalidDataFormatException.Message, context, StatusCodes.Status400BadRequest,InvalidDataFormatException.StackTrace);
            }
            catch (Exception UnsupportedException)
            {
                await HandleExceptionAsync(UnsupportedException.Message, context, StatusCodes.Status501NotImplemented,UnsupportedException.StackTrace);
            }

        }
        private async Task HandleExceptionAsync(string exceptionMessage, HttpContext context, int statusCode, string stackTrace = null)
        {
            var response = new ErrorResponse(exceptionMessage, statusCode);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var jsonResponse = JsonSerializer.Serialize(response);
            var responseBytes = Encoding.UTF8.GetBytes(jsonResponse);

            await context.Response.Body.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }

    public class ErrorResponse
    {
        public string ErrorMessage {  get; set; }
        public int StatusCode {  get; set; }
        public ErrorResponse(string errorMessage, int statusCode)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }

}
