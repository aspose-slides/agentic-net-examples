using System;
using System.IO;
using System.Xml.Serialization;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InkDeserializationExample
{
    // Simple class representing ink data in XML
    [XmlRoot("InkData")]
    public class InkData
    {
        [XmlElement("X")]
        public float X { get; set; }

        [XmlElement("Y")]
        public float Y { get; set; }

        [XmlElement("Width")]
        public float Width { get; set; }

        [XmlElement("Height")]
        public float Height { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string xmlPath = "inkData.xml";
            string outputPath = "OutputPresentation.pptx";

            // Verify that the XML file exists
            if (!File.Exists(xmlPath))
            {
                Console.WriteLine("XML file not found: " + xmlPath);
                return;
            }

            // Deserialize the XML into InkData object
            InkData inkData;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(InkData));
                using (FileStream fs = new FileStream(xmlPath, FileMode.Open))
                {
                    inkData = (InkData)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deserializing XML: " + ex.Message);
                return;
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide (created by default)
                ISlide slide = presentation.Slides[0];

                // Add a line shape as a placeholder for ink (Aspose.Slides does not provide a direct Ink constructor)
                // The shape can later be cast to Aspose.Slides.Ink.Ink if needed.
                IAutoShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, inkData.X, inkData.Y, inkData.Width, inkData.Height);

                // Example of casting to Ink (if the shape is actually an Ink shape)
                // Aspose.Slides.Ink.Ink inkShape = lineShape as Aspose.Slides.Ink.Ink;
                // if (inkShape != null)
                // {
                //     // Apply additional ink-specific properties here
                // }

                // Save the presentation
                try
                {
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to " + outputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}