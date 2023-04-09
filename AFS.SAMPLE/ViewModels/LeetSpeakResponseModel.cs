namespace AFS.SAMPLE.ViewModels;
public sealed record LeetSpeakResponseModel
{
    public LeetSpeakResponseStatus Success { get; set; }
    public LeetSpeakResponseContent Contents { get; set; }
}

public record LeetSpeakResponseStatus
{
    public int Total { get; set; }
}

public record LeetSpeakResponseContent
{
    public string Translated { get; set; }
    public string Text { get; set; }
    public string Translation { get; set; }
}
