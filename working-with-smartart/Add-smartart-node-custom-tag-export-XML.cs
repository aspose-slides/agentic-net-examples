using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram
                ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    0, 0, 400, 400,
                    Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Add a new node to the SmartArt
                ISmartArtNode newNode = smartArt.Nodes.AddNode();

                // Assign a custom tag using the shape's Name property
                if (newNode.Shapes.Count > 0)
                {
                    newNode.Shapes[0].Name = "CustomTag=MyValue";
                }

                // Export node-to-tag mapping to an XML file
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("SmartArtMapping");
                xmlDoc.AppendChild(root);

                foreach (ISmartArtNode node in smartArt.AllNodes)
                {
                    XmlElement nodeElem = xmlDoc.CreateElement("Node");
                    if (node.TextFrame != null && node.TextFrame.Text != null)
                    {
                        nodeElem.SetAttribute("Text", node.TextFrame.Text);
                    }

                    if (node.Shapes.Count > 0)
                    {
                        string tag = node.Shapes[0].Name;
                        nodeElem.SetAttribute("Tag", tag);
                    }

                    root.AppendChild(nodeElem);
                }

                string xmlPath = "SmartArtMapping.xml";
                xmlDoc.Save(xmlPath);

                // Save the presentation
                presentation.Save("SmartArtPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}