using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtLayoutReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string xmlConfigPath = "layoutConfig.xml";
            string outputPath = "output.pptx";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            // Verify that the XML configuration file exists
            if (!File.Exists(xmlConfigPath))
            {
                Console.WriteLine("XML configuration file not found: " + xmlConfigPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Load the desired SmartArt layout from the XML file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlConfigPath);
            XmlNode layoutNode = xmlDoc.SelectSingleNode("//Layout");
            if (layoutNode == null || string.IsNullOrWhiteSpace(layoutNode.InnerText))
            {
                Console.WriteLine("Layout element not found or empty in XML configuration.");
                return;
            }

            // Parse the layout string to SmartArtLayoutType enum
            SmartArtLayoutType desiredLayout;
            try
            {
                desiredLayout = (SmartArtLayoutType)Enum.Parse(typeof(SmartArtLayoutType), layoutNode.InnerText.Trim(), true);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid layout type specified in XML: " + layoutNode.InnerText);
                return;
            }

            // Find the first SmartArt shape on the first slide and replace its layout
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    smartArt.Layout = desiredLayout;
                    break; // Assuming only one SmartArt needs to be changed
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}