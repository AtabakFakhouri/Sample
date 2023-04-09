using AFS.SAMPLE.Helper.Enums;

namespace AFS.SAMPLE.ViewModels;

public record LoginModel
{
    public string UserName { get; set; }
    public string Password { get; set; }

}
