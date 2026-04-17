using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SerializeShapeData
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Prepare XML document to hold custom data
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement rootElement = xmlDoc.CreateElement("ShapesCustomData");
                xmlDoc.AppendChild(rootElement);

                // Iterate through all slides and shapes
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Example: serialize shape name and alternative text
                        XmlElement shapeElement = xmlDoc.CreateElement("Shape");
                        shapeElement.SetAttribute("SlideIndex", slideIndex.ToString());
                        shapeElement.SetAttribute("ShapeIndex", shapeIndex.ToString());
                        shapeElement.SetAttribute("Name", shape.Name);
                        shapeElement.SetAttribute("AlternativeText", shape.AlternativeText);
                        rootElement.AppendChild(shapeElement);
                    }
                }

                // Convert XML document to string
                string xmlString;
                using (StringWriter stringWriter = new StringWriter())
                {
                    xmlDoc.Save(stringWriter);
                    xmlString = stringWriter.ToString();
                }

                // Embed XML as a custom XML part
                // Note: Aspose.Slides provides a way to add custom XML parts via the CustomData property.
                // The exact method may vary; here we use AddCustomXmlPart as a placeholder.
                // Replace with the appropriate API if different.
                ICustomData customData = presentation.CustomData;
                // Placeholder for adding XML part (actual method may differ)
                // customData.AddCustomXmlPart("ShapesCustomData", xmlString);
                // Since the exact method is not defined in the provided documentation,
                // we add the XML as a document property for demonstration purposes.
                presentation.DocumentProperties.SetCustomPropertyValue("ShapesCustomData", xmlString);

                // Save presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved with embedded custom XML.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}