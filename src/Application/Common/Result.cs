namespace OI.Template.Application.Common;

public class Result
{
    internal  Result(bool success, IEnumerable<string> errorCollection)
    {
        Succeded = success;
        Errors = errorCollection.ToArray();
    }

    public bool Succeded { get; set; }
    public string[] Errors { get; set; }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Failure(IEnumerable<string> errorCollection)
    {
        return new Result(false, errorCollection);
    }
}