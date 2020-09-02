import untangle
import shutil
import os
import sys
import zipfile

#=======================================Start Functions Declarations============================================
def copyFile(src, dst):
    dstDir = os.path.dirname(dst)
    if not os.path.exists(dstDir):
        os.makedirs(dstDir)
    shutil.copyfile(src, dst)

def copyProjectItem(projectItem, projectPath):
    fileName = projectItem["TargetFileName"]
    projectItemPath = os.path.join(rootSrcPath, projectPath, fileName)
    dst = os.path.join(dstRoot, projectPath, fileName)
    copyFile(projectItemPath, dst)

def processProjectFolder(projectFolder, projectPath):
    if hasattr(projectFolder, "ProjectItem"):
        projectItems = projectFolder.ProjectItem
        for projectItem in projectItems:
            copyProjectItem(projectItem, projectPath)
    if hasattr(projectFolder, "Folder"):
        projectFolders = projectFolder.Folder
        for folder in projectFolders:
            folderName = folder["TargetFolderName"]
            processProjectFolder(folder, os.path.join(projectPath, folderName))

def processProjectTemplate(projectTemplatePath):
    fullSrcPrjTemplatePath = os.path.join(rootSrcPath, projectTemplatePath)
    fullDstPrjTemplatePath = os.path.join(dstRoot, projectTemplatePath)
    copyFile(fullSrcPrjTemplatePath, fullDstPrjTemplatePath)
    
    projectObj = untangle.parse(fullSrcPrjTemplatePath)    
    projectPath = os.path.dirname(projectTemplatePath)
    prjFile = projectObj.VSTemplate.TemplateContent.Project["TargetFileName"]
    prjSrcDir = os.path.dirname(fullSrcPrjTemplatePath)
    prjDstDir = os.path.dirname(fullDstPrjTemplatePath)
    copyFile(os.path.join(prjSrcDir, prjFile), os.path.join(prjDstDir, prjFile))
    processProjectFolder(projectObj.VSTemplate.TemplateContent.Project, projectPath)
#=========================================End Functions Declarations=============================================

rootVsTemplateFile = os.path.abspath(sys.argv[1])
rootSrcPath = os.path.dirname(rootVsTemplateFile)
templateFileName = os.path.splitext(os.path.basename(rootVsTemplateFile))[0]
dstRoot = os.path.join(os.path.abspath(sys.argv[2]), templateFileName)

obj = untangle.parse(rootVsTemplateFile)

copyFile(rootVsTemplateFile, os.path.join(dstRoot, os.path.basename(rootVsTemplateFile)))

iconFile = obj.VSTemplate.TemplateData.Icon.cdata
copyFile(os.path.join(rootSrcPath, iconFile), os.path.join(dstRoot, iconFile))

templateContent = obj.VSTemplate.TemplateContent
if (hasattr(templateContent, 'ProjectCollection')):
    projectsInfo = templateContent.ProjectCollection.ProjectTemplateLink
    for projectInfo in projectsInfo:
        projectTemplatePath = projectInfo.cdata.strip()
        processProjectTemplate(projectTemplatePath)
elif (hasattr(templateContent, 'Project')):
    projectName = templateContent.Project['TargetFileName']
    copyFile(os.path.join(rootSrcPath, projectName), os.path.join(dstRoot, projectName))
    processProjectFolder(templateContent.Project, '')

shutil.make_archive(os.path.join(os.path.abspath(sys.argv[2]), templateFileName), "zip", dstRoot)

shutil.rmtree(dstRoot)