using GitVersion.Logging;
using GitVersion.OutputVariables;

namespace GitVersion.Agents;

internal class GitLabCi : BuildAgentBase
{
    public const string EnvironmentVariableName = "GITLAB_CI";
    private string? file;

    public GitLabCi(IEnvironment environment, ILog log) : base(environment, log) => WithPropertyFile("gitversion.properties");

    public void WithPropertyFile(string propertiesFileName) => this.file = propertiesFileName;

    protected override string EnvironmentVariable => EnvironmentVariableName;

    public override string GenerateSetVersionMessage(GitVersionVariables variables) => variables.FullSemVer;

    public override string[] GenerateSetParameterMessage(string name, string? value) => new[]
    {
        $"GitVersion_{name}={value}"
    };

    public override string? GetCurrentBranch(bool usingDynamicRepos)
    {
        string? branch = Environment.GetEnvironmentVariable("CI_COMMIT_BRANCH");
        if (branch != null && branch.Equals(string.Empty, StringComparison.OrdinalIgnoreCase))
            branch = null;

        return branch;
    }

    public override bool PreventFetch() => true;

    public override void WriteIntegration(Action<string?> writer, GitVersionVariables variables, bool updateBuildNumber = true)
    {
        if (this.file is null)
            return;

        base.WriteIntegration(writer, variables, updateBuildNumber);
        writer($"Outputting variables to '{this.file}' ... ");

        File.WriteAllLines(this.file, GenerateBuildLogOutput(variables));
    }
}
