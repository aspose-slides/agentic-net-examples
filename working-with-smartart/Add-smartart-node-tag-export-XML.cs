using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace AddSmartArtNodeTagExportXML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                // Add a new node to the SmartArt
                ISmartArtNode newNode = smartArt.Nodes.AddNode();

                // Assign a custom tag attribute using the AlternativeText of the first shape in the node
                if (newNode.Shapes.Count > 0)
                {
                    newNode.Shapes[0].AlternativeText = "CustomTagValue";
                }

                // Export the node-tag mapping to an XML file
                string xmlPath = "SmartArtNodeTagMapping.xml";
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement rootElement = xmlDoc.CreateElement("SmartArtNodeTagMapping");
                xmlDoc.AppendChild(rootElement);

                int nodeIndex = 0;
                foreach (ISmartArtNode node in smartArt.Nodes)
                {
                    XmlElement nodeElement = xmlDoc.CreateElement("Node");
                    nodeElement.SetAttribute("Index", nodeIndex.ToString());

                    string tagValue = string.Empty;
                    if (node.Shapes.Count > 0)
                    {
                        tagValue = node.Shapes[0].AlternativeText;
                    }
                    nodeElement.SetAttribute("Tag", tagValue);
                    rootElement.AppendChild(nodeElement);
                    nodeIndex++;
                }

                // Ensure the directory for the XML file exists
                string xmlDirectory = Path.GetDirectoryName(Path.GetFullPath(xmlPath));
                if (!Directory.Exists(xmlDirectory))
                {
                    Directory.CreateDirectory(xmlDirectory);
                }

                // Save the XML mapping
                xmlDoc.Save(xmlPath);

                // Save the presentation
                try
                {
                    presentation.Save("SmartArtPresentation.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions if needed
                }
            }
        }
    }
}