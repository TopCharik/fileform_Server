using System.Text.Json;

namespace FileForm.Api.Dto;

public class ApiError
{
    public string Title { get; set; }
    public int Status { get; set; }
    public Dictionary<string, string[]> Errors { get; set; }


    public ApiError(int status)
    {
        Status = status;
        Title = GetDefaultTitle(status);
        Errors = new();
    }
    
    
    private string GetDefaultTitle(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad Request",
            401 => "Unauthorized",
            404 => "Not Found",
            500 => "Internal Server Error",
            _   => "Unknown Error",
        };
    }
    
    public string ToJson()
    {
        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        var json = JsonSerializer.Serialize(this, options);

        return json;
    }
}