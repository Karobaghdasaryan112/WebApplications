
using S.P.WithCleanArchitecture.Application.Services.LoggerService;

namespace S.P.WithCleanArchitecture.Application.Interfaces
{
   
    public interface ILoggerService
    {
        Task LogIntoFile(LogObject LogObject);
    }
}
