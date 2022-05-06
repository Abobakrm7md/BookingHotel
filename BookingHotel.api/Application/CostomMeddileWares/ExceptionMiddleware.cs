using BookingHotel.BLL.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookingHotel.api.Application.CostomMeddileWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {

                await _next(httpContext);

                if (httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    var owinResponse = httpContext.Response;
                    var owinResponseStream = owinResponse.Body;
                    var responseBuffer = new MemoryStream();
                    owinResponse.Body = responseBuffer;

                    var UnothrizedMsg = new MessageModel()
                    {
                        Id = (int)HttpStatusCode.Unauthorized,
                        Message = "Unauthorized Request"

                    };
                    var customResponseBody = new StringContent(JsonConvert.SerializeObject(UnothrizedMsg));
                    var customResponseStream = await customResponseBody.ReadAsStreamAsync();
                    owinResponse.ContentType = "application/json";
                    owinResponse.ContentLength = customResponseStream.Length;
                    owinResponse.StatusCode = 401;
                    owinResponse.Body = owinResponseStream;
                    await customResponseStream.CopyToAsync(owinResponseStream);


                }


            }
            catch (InvalidJwtException ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleException(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleException(httpContext, ex);
            }
        }

        private Task HandleException(HttpContext context, InvalidJwtException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            string Reponse = JsonConvert.SerializeObject(new MessageModel()
            {
                Id = (int)HttpStatusCode.Unauthorized,
                Message = ex.Message

            });
            return context.Response.WriteAsync(Reponse);

        }
        
        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string Reponse = JsonConvert.SerializeObject(new MessageModel()
            {
                Id = (int)HttpStatusCode.InternalServerError,
                Message = exception.Message

            });
            return context.Response.WriteAsync(Reponse);
        }
    }
}
