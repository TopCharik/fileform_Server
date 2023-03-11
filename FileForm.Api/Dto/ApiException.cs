namespace FileForm.Api.Dto;

public class ApiException : ApiError
{
    public ApiException() : base(500)
    {
        var errors = new Dictionary<string, string[]>();
        errors.Add("Internal Server Error", new []{"Try again later"});
        Errors = errors;
    }
}