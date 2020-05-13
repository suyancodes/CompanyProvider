using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CompanyProvider.API.Filters
{
    public class HttpResponseExceptionFilter :  IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ContentType = "application/json";
            context.Result = new JsonResult( new { message = context.Exception.Message });

        }
    }
}
