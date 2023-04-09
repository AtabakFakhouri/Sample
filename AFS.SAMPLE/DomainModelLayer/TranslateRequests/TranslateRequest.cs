using AFS.SAMPLE.DomainModelLayer.Users;
using AFS.SAMPLE.Helper.Domain;

namespace AFS.SAMPLE.DomainModelLayer.Requests;

public class TranslateRequest : TransactionRoot<int>
{
    public int UserId { get; set; }
    public User User { get; set; }
    public string InputText { get; set; }
    public int ResponseTotal { get; set; }
    public string ResponseTranslated { get; set; }
    public string ResponseText { get; set; }
    public string ResponseTranslation { get; set; }
    
}
