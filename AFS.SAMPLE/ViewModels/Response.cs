using System.Net;

namespace AFS.SAMPLE.ViewModels;

public abstract class Response
{
    public static readonly string SuccessfulMessage = "Transaction Successful";
    public static readonly string ErrorMessage = "System Error";
    public Response(bool statusVal, HttpStatusCode resultCodeVal, string messageVal, string tokenVal, object dataVal)
    {
        status = statusVal;
        resultCode = resultCodeVal;
        message = messageVal;
        token = tokenVal;
        data = dataVal;
    }

    public bool status { get; set; }
    public HttpStatusCode resultCode { get; set; }
    public string message { get; set; }
    public string token { get; set; }
    public object data { get; set; }
}

public class SuccessfulResponse : Response
{
    public SuccessfulResponse(string message = "") : base(true, HttpStatusCode.OK, string.IsNullOrEmpty(message) ? SuccessfulMessage : message, string.Empty, null)
    {
    }

    public SuccessfulResponse(object data) : base(true, HttpStatusCode.OK, SuccessfulMessage, string.Empty, data)
    {
    }
    public SuccessfulResponse(string message, object data) : base(true, HttpStatusCode.OK, message, string.Empty, data)
    {
    }
}

public class ErrorResponse : Response
{
    public ErrorResponse(string message = "", HttpStatusCode resultCode = HttpStatusCode.InternalServerError, object data = null) : base(false, resultCode, string.IsNullOrEmpty(message) ? ErrorMessage : message, string.Empty, data)
    {
    }

}

