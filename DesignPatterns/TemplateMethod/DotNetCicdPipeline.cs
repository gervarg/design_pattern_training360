using System;

namespace TemplateMethod
{
    internal class DotNetCicdPipeline : CicdPipeline
    {
        internal override void BuildTheCode()
        {
            Console.WriteLine("Build the project with MSBuild.");
        }

        internal override void DeployArtifact()
        {
            Console.WriteLine("Copy versioned zip to TFS deploy folder.");
        }

        internal override void GetCodeFromVersionControlSystem()
        {
            Console.WriteLine("Get the latest version of code from TFS.");
        }

        internal override void ResolveDependencies()
        {
            Console.WriteLine("Download Nuget packages.");
        }

        internal override void RunCodeAnalyzer()
        {
            Console.WriteLine("Run Visual Studio Static Code Analyzer.");
        }

        internal override void RunUnitTests()
        {
            Console.WriteLine("Run unit test with Nunit.");
        }
    }
}
