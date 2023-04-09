using AFS.SAMPLE.DomainModelLayer.ExceptionLogs;
using AFS.SAMPLE.DomainModelLayer.Requests;
using AFS.SAMPLE.Helper.Domain;
using AFS.SAMPLE.Helper.Enums;

namespace AFS.SAMPLE.DomainModelLayer.Users;

public class User : TransactionRoot<int>
{    
    public RoleType Role { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int TokenExpiredMinute { get; set; }

    public virtual ICollection<TranslateRequest> Requests { get; set; }
    public virtual ICollection<ExceptionLog> ExceptionLogs { get; set; }
}
