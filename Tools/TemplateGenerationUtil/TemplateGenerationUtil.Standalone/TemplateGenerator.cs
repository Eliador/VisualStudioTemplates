using System;
using System.IO;
using System.IO.Compression;
using TemplateGenerationUtil.Standalone.VsTemplate;

namespace TemplateGenerationUtil.Standalone
{
    public class TemplateGenerator
    {
        public void Generate(string rootTemplatePath, string outputPath)
        {
            var outputTmpPath = Path.Combine(outputPath, "Temp");

            try
            {
                CopyTemplateSources(rootTemplatePath, outputTmpPath);

                var zipFileName = Path.GetFileNameWithoutExtension(rootTemplatePath);
                var destArchiveFile = Path.Combine(outputPath, $"{zipFileName}.zip");
                if (File.Exists(destArchiveFile))
                {
                    File.Delete(destArchiveFile);
                }

                ZipFile.CreateFromDirectory(outputTmpPath, destArchiveFile);

                Directory.Delete(outputTmpPath, true);
            }
            catch (Exception ex)
            {
                Directory.Delete(outputTmpPath, true);
                throw ex;
            }
        }

        private void CopyTemplateSources(string rootTemplatePath, string outputPath)
        {
            var fileName = Path.GetFileName(rootTemplatePath);
            var destFile = Path.Combine(outputPath, fileName);
            CopyToTempFolder(rootTemplatePath, destFile);

            var rootTemplateDocument = new VsTemplateDocument(rootTemplatePath);
            var templateProjectsPaths = rootTemplateDocument.GetProjectTemplateLinks();

            var rootPath = Path.GetDirectoryName(rootTemplatePath);
            foreach (var templateProjectPath in templateProjectsPaths)
            {
                ProcessProjectTemplate(templateProjectPath, rootPath, outputPath);
            }
        }

        private void CopyToTempFolder(string sourceFile, string destFile)
        {
            var destFolder = Path.GetDirectoryName(destFile);

            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            File.Copy(sourceFile, destFile);
        }

        private void ProcessProjectTemplate(string templateRelativePath, string rootPath, string outputTmpPath)
        {
            var templatePath = Path.Combine(rootPath, templateRelativePath);
            var destPath = Path.Combine(outputTmpPath, templateRelativePath);

            CopyToTempFolder(templatePath, destPath);

            var templateDocument = new VsTemplateDocument(templatePath);
            var templateItems = templateDocument.GetProjectTemplateItems();

            var sourceDir = Path.GetDirectoryName(templatePath);
            var destDir = Path.GetDirectoryName(destPath);
            foreach (var templateItem in templateItems)
            {
                var sourceFile = Path.Combine(sourceDir, templateItem);
                var destFile = Path.Combine(destDir, templateItem);
                CopyToTempFolder(sourceFile, destFile);
            }
        }
    }
}
