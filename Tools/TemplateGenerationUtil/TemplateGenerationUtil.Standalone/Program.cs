using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;
using TemplateGenerationUtil.Core;

namespace TemplateGenerationUtil.Standalone
{
    class Program
    {
        static void Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();
            using (var workspace = MSBuildWorkspace.Create())
            {
                var solution = workspace.OpenSolutionAsync(args[0]).Result;

                var templateGenerator = new TemplateGenerator();
                templateGenerator.Generate(solution);
            }
        }
    }
}
