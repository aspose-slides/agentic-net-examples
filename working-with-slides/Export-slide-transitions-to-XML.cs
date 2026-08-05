// -----------------------------------------------------------------------------
// Example: Export slide transitions to XML using C#
//
// Description:
// Demonstrates how to extract slide transition settings from a PowerPoint
// presentation and export them to an XML file using C# and Aspose.Slides for .NET.
// The example loads an existing PPTX file, iterates through its slides,
// captures transition properties, writes them to an XML document, and saves
// both the XML configuration and a copy of the (potentially unchanged) presentation.
// This pattern can be used to automate PPTX analysis, generate reports, or
// integrate transition data into other workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide, Transitions, XML,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of slide transition details to XML for reporting.
// - Build C# tools that analyze or audit PowerPoint presentation animations.
// - Integrate slide transition data into custom .NET applications or services.
// - Validate and document presentation workflows before publishing.
// -----------------------------------------------------------------------------

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
