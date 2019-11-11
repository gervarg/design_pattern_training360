using System;

namespace TemplateMethod
{
    internal class NodeJsCicdPipeline : CicdPipeline
    {
        internal override void BuildTheCode()
        {
            Console.WriteLine("SKIP: JavaScript does not need to build.");
        }

        internal override void DeployArtifact()
        {
            Console.WriteLine("Upload versioned zip to Artifactory.");
        }

        internal override void GetCodeFromVersionControlSystem()
        {
            Console.WriteLine("Get the latest version of code from GIT repo.");
        }

        internal override void ResolveDependencies()
        {
            Console.WriteLine("Restore npm packages.");
        }

        internal override void RunCodeAnalyzer()
        {
            Console.WriteLine("Run ESLint.");
        }

        internal override void RunUnitTests()
        {
            Console.WriteLine("Run unit test with Mocha.");
        }
    }
}
