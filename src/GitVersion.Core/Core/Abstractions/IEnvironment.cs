namespace GitVersion;

public interface IEnvironment
{
    string? GetEnvironmentVariable(string variableName);
    string? GetEnvironmentVariable(string variableName, EnvironmentVariableTarget target);
    void SetEnvironmentVariable(string variableName, string? value);
}
