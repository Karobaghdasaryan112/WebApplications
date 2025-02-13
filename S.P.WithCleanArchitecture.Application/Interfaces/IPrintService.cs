namespace S.P.WithCleanArchitecture.Application.Interfaces
{
    public interface IPrintService
    {
        string GetPrintInfo<TPrint>(TPrint print,HashSet<object> visited = null);
    }
}
