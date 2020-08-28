using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;

namespace MonolithicWebApp.Wizard
{
    public class TemplateWizard : IWizard
    {
        private static string basename;

        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(EnvDTE.Project project)
        {
        }

        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            if (runKind == WizardRunKind.AsMultiProject)
            {
                basename = replacementsDictionary["$specifiedsolutionname$"];
            }
            else
            {
                replacementsDictionary["$safeprojectname$"] = basename;
            }
        }
    }
}
