using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using System.Drawing;

namespace InkDeserializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the XML ink data and the output presentation
            string xmlFilePath = "inkData.xml";
            string outputPresentationPath = "InkPresentation_out.pptx";

            // Verify that the XML file exists
            if (!File.Exists(xmlFilePath))
            {
                Console.WriteLine("The specified XML file does not exist: " + xmlFilePath);
                return;
            }

            // Load the XML document containing ink data
            XmlDocument inkXml = new XmlDocument();
            try
            {
                inkXml.Load(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load XML file. Exception: " + ex.Message);
                return;
            }

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide (a new presentation always contains one empty slide)
                ISlide slide = pres.Slides[0];

                // Add a line shape that will act as an ink placeholder
                // Using ShapeType.Line and later applying a scribble sketch style
                IAutoShape inkShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

                // Apply scribble sketch to simulate ink drawing
                if (inkShape.LineFormat != null && inkShape.LineFormat.SketchFormat != null)
                {
                    inkShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;
                }

                // Optional: set line color based on XML data (example assumes a <Color>#FF0000</Color> node)
                XmlNode colorNode = inkXml.SelectSingleNode("//Color");
                if (colorNode != null)
                {
                    try
                    {
                        Color parsedColor = ColorTranslator.FromHtml(colorNode.InnerText);
                        inkShape.LineFormat.FillFormat.SolidFillColor.Color = parsedColor;
                    }
                    catch
                    {
                        // If color parsing fails, ignore and keep default color
                    }
                }

                // Save the presentation
                try
                {
                    pres.Save(outputPresentationPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved successfully to: " + outputPresentationPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format exception (commented as per requirement)
                    // Format not supported
                    Console.WriteLine("Failed to save presentation. Exception: " + ex.Message);
                }
            }
        }
    }
}