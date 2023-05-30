namespace MudBlazor.DTO_s;

public class GetGitHubRepositoriesDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? HtmlUrl { get; set; }
    public string? Url { get; set; }
}