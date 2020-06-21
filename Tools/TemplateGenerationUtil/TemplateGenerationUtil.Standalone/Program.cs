using System;

namespace TemplateGenerationUtil.Standalone
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = ParseArguments(args);
            if (string.IsNullOrWhiteSpace(context.RootTemplatePath)
                || string.IsNullOrWhiteSpace(context.OutputPath))
            {
                throw new Exception(); // TODO
            }

            var templateGenerator = new TemplateGenerator();
            templateGenerator.Generate(context.RootTemplatePath, context.OutputPath);
        }

        private static (string RootTemplatePath, string OutputPath) ParseArguments(string[] args)
        {
            string rootTemplatePath = null;
            string outputPath = null;
            for (var i = 1; i < args.Length; i += 2)
            {
                switch (args[i - 1])
                {
                    case "-rt":
                        rootTemplatePath = args[i];
                        break;
                    case "-o":
                        outputPath = args[i];
                        break;
                }
            }

            return (RootTemplatePath: rootTemplatePath, OutputPath: outputPath);
        }
    }
}
