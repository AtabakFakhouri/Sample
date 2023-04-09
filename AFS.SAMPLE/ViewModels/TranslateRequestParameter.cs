namespace AFS.SAMPLE.ViewModels;

public sealed record TranslateRequestParameter
{
    public string UserName { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string InputText { get; set; }
    public string Translation { get; set; }
}