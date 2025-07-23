using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MailSender.Middlewares;


public class ExceptionHandler(IProblemDetailsService problemDetailsService, ILogger<ExceptionHandler> logger) : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ProblemDetails? problemDetails = null;
        int? statusCode;


        statusCode = StatusCodes.Status500InternalServerError;
        problemDetails = new()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Извините, произошла непредвиденная ошибка",
            Detail = "Мы уже работаем над ее устранением. Пожалуйста, попробуйте снова позже",
        };

        //problemDetails ??= new() Прикольная тема с ??=
        //{
        //    Status = statusCode,
        //    Title = exception.Message,
        //};

        logger.LogError(exception, "Произошло исключение: {Message}", exception.Message);

        httpContext.Response.StatusCode = statusCode.Value;

        return problemDetailsService.TryWriteAsync(new()
        {
            Exception = exception,
            HttpContext = httpContext,
            ProblemDetails = problemDetails,
        });
    }
}
