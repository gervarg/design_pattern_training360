namespace TemplateMethod
{
    // https://en.wikipedia.org/wiki/CI/CD
    internal abstract class CicdPipeline
    {
        internal void Run()
        {
            GetCodeFromVersionControlSystem();
            ResolveDependencies();
            BuildTheCode();
            RunUnitTests();
            RunCodeAnalyzer(); // linter
            DeployArtifact();
        }

        internal abstract void GetCodeFromVersionControlSystem();
        internal abstract void ResolveDependencies();
        internal abstract void BuildTheCode();
        internal abstract void RunUnitTests();
        internal abstract void RunCodeAnalyzer();
        internal abstract void DeployArtifact();
    }
}
