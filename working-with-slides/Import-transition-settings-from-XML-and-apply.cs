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

                    // Apply transition settings using the better-slide-transitions pattern
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
                // Format not supported.
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