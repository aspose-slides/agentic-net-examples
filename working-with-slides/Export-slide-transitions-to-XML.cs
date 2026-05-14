using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input presentation, output presentation, and XML configuration
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string xmlPath = "transitions.xml";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create an XML document to store transition settings
            XDocument xmlDoc = new XDocument(new XElement("Slides"));

            // Iterate through each slide and extract transition information
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;

                XElement slideElement = new XElement("Slide",
                    new XAttribute("Index", i),
                    new XElement("Type", transition.Type.ToString()),
                    new XElement("AdvanceOnClick", transition.AdvanceOnClick),
                    new XElement("AdvanceAfterTime", transition.AdvanceAfterTime));

                xmlDoc.Root.Add(slideElement);
            }

            // Save the XML configuration
            xmlDoc.Save(xmlPath);

            // Save the (potentially unchanged) presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}