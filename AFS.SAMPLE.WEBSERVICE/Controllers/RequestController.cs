using AFS.SAMPLE.ApplicationLayer.Users;
using AFS.SAMPLE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace AFS.SAMPLE.WEBSERVICE.Controllers;

[ApiController]
[Authorize]
[Route("Request")]
public class RequestController : ControllerBase
{
    readonly ITranslateRequestService RequestService;

    public RequestController(ITranslateRequestService RequestService)
    {
        this.RequestService = RequestService;
    }

    [HttpGet]
    [Route("LeetSpeakTranslate")]
    public async Task<Response> LeetSpeakTranslate(string text) => await this.RequestService.LeetSpeakTranslate(text);


    [HttpPost]
    [Route("GridList")]
    [AllowAnonymous]
    public IActionResult GridList(TranslateRequestParameter parameter)
    {
        var res = this.RequestService.GridList(parameter);
        if (res == null)
            return NotFound();

        return Ok(res);
    }
}
