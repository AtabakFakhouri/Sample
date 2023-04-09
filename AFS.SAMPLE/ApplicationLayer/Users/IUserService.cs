using AFS.SAMPLE.ViewModels;

namespace AFS.SAMPLE.ApplicationLayer.Users
{
    public interface IUserService
    {
        Response SignIn(LoginModel model);
    }
}
