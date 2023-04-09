using AFS.SAMPLE.DomainModelLayer.ExceptionLogs;
using AFS.SAMPLE.ViewModels;

namespace AFS.SAMPLE.ApplicationLayer.ExceptionLogs;

public interface IExceptionLogService
{
    Task<Response> AddAsync(ExceptionLog model);
}
