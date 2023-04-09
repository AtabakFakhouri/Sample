using AFS.SAMPLE.ViewModels;

namespace AFS.SAMPLE.ApplicationLayer.Users
{
    public interface ITranslateRequestService
    {
        Task<Response> LeetSpeakTranslate(string inputText);
        List<TranslateGridModel> GridList(TranslateRequestParameter parameter);
    }
}
