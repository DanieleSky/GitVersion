namespace GitVersion.Core.Tests.Helpers;

public class TestEnvironment : IEnvironment
{
    private readonly IDictionary<string, string?> map = new Dictionary<string, string?>();

    public string? GetEnvironmentVariable(string variableName) => this.map.TryGetValue(variableName, out var val) ? val : null;
    public string? GetEnvironmentVariable(string variableName, EnvironmentVariableTarget target) => this.GetEnvironmentVariable(variableName);

    public void SetEnvironmentVariable(string variableName, string? value) => this.map[variableName] = value;
}
