namespace GitVersion;

internal class Environment : IEnvironment
{
    public string? GetEnvironmentVariable(string variableName) => SysEnv.GetEnvironmentVariable(variableName);
    public string? GetEnvironmentVariable(string variableName, EnvironmentVariableTarget target) => SysEnv.GetEnvironmentVariable(variableName, target);

    public void SetEnvironmentVariable(string variableName, string? value) => SysEnv.SetEnvironmentVariable(variableName, value);
}
