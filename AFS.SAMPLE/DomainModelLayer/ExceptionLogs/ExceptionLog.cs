using AFS.SAMPLE.DomainModelLayer.Users;
using AFS.SAMPLE.Helper.Domain;
using System.Net;

namespace AFS.SAMPLE.DomainModelLayer.ExceptionLogs;

public class ExceptionLog : TransactionRoot<int>
{
    public int? UserId { get; set; }
    public User User { get; set; }    
    public string StackTrace { get; set; }
    public string InnerStackTrace { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
