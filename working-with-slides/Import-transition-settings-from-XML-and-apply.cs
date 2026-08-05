// -----------------------------------------------------------------------------
// Example: Import transition settings from XML and apply using C#
//
// Description:
// Demonstrates how to read an XML file that defines slide transition
// parameters (slide index, transition type, and advance time) and apply those
// settings to a PowerPoint presentation using Aspose.Slides for .NET. The
// example loads an existing PPTX, updates each slide's SlideShowTransition
// properties according to the XML, and saves the modified presentation.
// This pattern can be used to programmatically control slide transitions in
// automated PPTX processing scenarios.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, XML, Slide transition, SlideShowTransition,
// Transition type, Advance time, Presentation automation
//
// Use Cases:
// - Apply batch transition settings defined in an external XML to a PPTX.
// - Build tools that synchronize slide animations with external data sources.
// - Automate preparation of presentations for webinars or e‑learning.
// - Integrate transition configuration into CI/CD pipelines for slide decks.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPresentationPath = "input.pptx";
            string xmlPath = "transitions.xml";
            string outputPresentationPath = "output.pptx";

            // Verify that the presentation file exists
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Presentation file not found: " + inputPresentationPath);
                return;
            }

            // Verify that the XML file exists
            if (!File.Exists(xmlPath))
            {
                Console.WriteLine("XML file not found: " + xmlPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPresentationPath);

                // Load the XML document containing transition settings
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                // Iterate over each Slide node in the XML
                XmlNodeList slideNodes = xmlDoc.SelectNodes("//Slide");
                foreach (XmlNode slideNode in slideNodes)
                {
                    // Parse slide index
                    int slideIndex = int.Parse(slideNode.Attributes["index"].Value);

                    // Parse transition type
                    string transitionTypeName = slideNode.Attributes["type"].Value;
                    Aspose.Slides.SlideShow.TransitionType transitionType = (Aspose.Slides.SlideShow.TransitionType)Enum.Parse(typeof(Aspose.Slides.SlideShow.TransitionType), transitionTypeName);

                    // Parse advance after time (in milliseconds)
                    uint advanceTime = uint.Parse(slideNode.Attributes["time"].Value);

                    // Apply transition settings
                    presentation.Slides[slideIndex].SlideShowTransition.Type = transitionType;
                    presentation.Slides[slideIndex].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[slideIndex].SlideShowTransition.AdvanceAfterTime = advanceTime;
                }

                // Save the modified presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
