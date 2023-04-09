using AFS.SAMPLE.DomainModelLayer.ExceptionLogs;
using AFS.SAMPLE.Helper.Repository;
using AFS.SAMPLE.ViewModels;
using Microsoft.AspNetCore.Http;

namespace AFS.SAMPLE.ApplicationLayer.ExceptionLogs;

public sealed class ExceptionLogService : IExceptionLogService
{
    readonly IRepository<ExceptionLog> exceptionLogRepository;
    readonly IUnitOfWork unitOfWork;
    protected readonly IHttpContextAccessor _httpContextAccessor;


    public ExceptionLogService(IUnitOfWork unitOfWork
        , IRepository<ExceptionLog> exceptionLogRepository,
        IHttpContextAccessor httpContextAccessor)       
    {
        this.exceptionLogRepository = exceptionLogRepository;
        this.unitOfWork = unitOfWork;        
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Response> AddAsync(ExceptionLog model)
    {
        try
        {
            var userId = int.Parse(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "Id")?.Value ?? "0");
            if (userId > 0)
                model.UserId = userId;

            this.exceptionLogRepository.Add(model);
            await unitOfWork.CommitAsync();
        }
        catch (Exception exp)
        {
            throw;
        }

        return new SuccessfulResponse();
    }

}
