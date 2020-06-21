using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace TemplateGenerationUtil.Standalone.VsTemplate
{
    internal class VsTemplateDocument
    {
        private const string XmlNamespacePrefix = "root";

        public static string Extension = "*.vstemplate";

        private XmlDocument _xmlDoc;
        private XmlNamespaceManager _namespaceManager;

        public VsTemplateDocument(string vsTemplatePath)
        {
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(vsTemplatePath);

            _namespaceManager = new XmlNamespaceManager(_xmlDoc.NameTable);
            _namespaceManager.AddNamespace(XmlNamespacePrefix, "http://schemas.microsoft.com/developer/vstemplate/2005");
        }

        public ICollection<string> GetProjectTemplateLinks()
        {
            var templateContentNode = GetTemplateContentNode();
            var projectCollection = templateContentNode
                .SelectSingleNode(GetNodeName(VsTemplateTag.ProjectCollectionNode), _namespaceManager);

            return projectCollection
                .SelectNodes(GetNodeName(VsTemplateTag.ProjectTemplateLinkNode), _namespaceManager)
                .Cast<XmlElement>()
                .Select(x => x.InnerText.Trim())
                .ToList();
        }

        private string GetNodeName(string name)
        {
            return $"//{XmlNamespacePrefix}:{name}";
        }

        private XmlNode GetTemplateContentNode()
        {
            var templateContentNode = _xmlDoc
                .SelectSingleNode(GetNodeName(VsTemplateTag.TemplateContentNode), _namespaceManager);
            if (templateContentNode == null)
            {
                throw new Exception(); // TODO
            }

            return templateContentNode;
        }

        public ICollection<string> GetProjectTemplateItems()
        {
            var projectItems = new List<string>();

            var templateContentNode = GetTemplateContentNode();

            var projectNode = templateContentNode
                .SelectSingleNode(GetNodeName(VsTemplateTag.ProjectNode), _namespaceManager);

            var projectName = projectNode.Attributes[VsTemplateTag.FileAttribute].Value;
            projectItems.Add(projectName);
            projectItems.AddRange(GetProjectItems(projectNode, string.Empty));

            return projectItems;
        }

        private ICollection<string> GetProjectItems(XmlNode rootNode, string path)
        {
            var items = new List<string>();

            foreach (var node in rootNode.ChildNodes.Cast<XmlNode>())
            {
                if (node.Name == VsTemplateTag.FolderNode)
                {
                    var folderName = node.Attributes[VsTemplateTag.NameAttribute].Value;
                    items.AddRange(GetProjectItems(node, Path.Combine(path, folderName)));
                }

                if (node.Name == VsTemplateTag.ProjectItemNode)
                {
                    var fileName = node.Attributes[VsTemplateTag.TargetFileNameAttribute].Value;
                    items.Add(Path.Combine(path, fileName));
                }
            }

            return items;
        }
    }
}
