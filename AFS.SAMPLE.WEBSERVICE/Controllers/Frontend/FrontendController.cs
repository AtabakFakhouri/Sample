using Microsoft.AspNetCore.Mvc;

namespace AFS.SAMPLE.WEBSERVICE.Controllers.Frontend
{
    public class FrontendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LeetSpeakTranslation()
        {
            return View();
        }

        public IActionResult TranslationReport()
        {
            return View();
        }
    }
}
