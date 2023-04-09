using AutoMapper;
using AFS.SAMPLE.Helper.Repository;
using AFS.SAMPLE.ViewModels;
using AFS.SAMPLE.Helper.Shared;
using AFS.SAMPLE.DomainModelLayer.Requests;
using Microsoft.AspNetCore.Http;

namespace AFS.SAMPLE.ApplicationLayer.Users
{
    public class TranslateRequestService : ITranslateRequestService
    {
        readonly IRepository<TranslateRequest> translateRequestRepository;
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;


        public TranslateRequestService(IRepository<TranslateRequest> translateRequestRepository,
         IUnitOfWork unitOfWork,
         IMapper mapper,
         IHttpContextAccessor httpContextAccessor)
        {
            this.translateRequestRepository = translateRequestRepository;
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response> LeetSpeakTranslate(string inputText)
        {
            var userId =int.Parse(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "Id")?.Value??"0");
            if(userId==0)
                return new ErrorResponse("Unauthorized error.");

            var newRequest = new TranslateRequest
            {
                UserId= userId,
                InputText=inputText,
                CreateDate=DateTime.Now                
            };

            var translateResult =await CommonHelper.PostAsync<LeetSpeakResponseModel>("https://api.funtranslations.com/translate/leetspeak.json", new Dictionary<string, string>() { { "text", inputText } });

            newRequest.ResponseTranslation = translateResult?.Contents?.Translation ?? string.Empty;
            newRequest.ResponseText = translateResult?.Contents?.Text ?? string.Empty;
            newRequest.ResponseTranslated = translateResult?.Contents?.Translated??string.Empty;
            newRequest.ResponseTotal = translateResult?.Success?.Total??0;

            this.translateRequestRepository.Add(newRequest);
            await unitOfWork.CommitAsync();

            if(newRequest.ResponseTotal>0)
                return new SuccessfulResponse(translateResult);

            if(translateResult.Success==null)
                return new ErrorResponse("Too Many Requests: Rate limit of 10 requests per hour exceeded. Please wait for 18 minutes and 1 second.");

            return new ErrorResponse("System Error");

        }

        public List<TranslateGridModel> GridList(TranslateRequestParameter parameter)
        {
            var query = this.translateRequestRepository.GetQueryble();

            if(parameter.FromDate.HasValue)
                query=query.Where(s=>s.CreateDate>=parameter.FromDate.Value);

            if (parameter.ToDate.HasValue)
                query = query.Where(s => s.CreateDate <= parameter.ToDate.Value);

            if (!string.IsNullOrEmpty(parameter.InputText))
                query = query.Where(s => s.InputText.Contains(parameter.InputText));

            if (!string.IsNullOrEmpty(parameter.Translation))
                query = query.Where(s => s.ResponseTranslated.Contains(parameter.Translation));

            if (!string.IsNullOrEmpty(parameter.UserName))
                query = query.Where(s => s.User.UserName.Contains(parameter.UserName));

            var result = query.Select(s => new TranslateGridModel
            {
                UserName=s.User!=null?s.User.UserName:"-",
                CreateDate=s.CreateDate.ToLocalTime().ToString("mm/dd/yyyy HH:mm:ss"),
                Text=s.InputText,
                Translation=!string.IsNullOrEmpty(s.ResponseTranslated)?s.ResponseTranslated:"no-result"
            }).ToList();

            return result;
        }

    }
}
