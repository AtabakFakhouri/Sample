using AFS.SAMPLE.ApplicationLayer.Users;
using AFS.SAMPLE.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AFS.SAMPLE.WEBSERVICE.Controllers;

[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    [Route("SignIn")]
    public Response SignIn(LoginModel model)
    {
        return this.userService.SignIn(model);
    }   
}
