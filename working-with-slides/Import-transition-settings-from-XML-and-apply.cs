// -----------------------------------------------------------------------------
// Example: Import slide transition settings from XML and apply to PPTX
//
// Description:
// This console program reads an XML file that defines slide transition parameters
// (slide index, transition type, and advance time) and applies them to a PowerPoint
// presentation using Aspose.Slides for .NET. It creates sample input files if they
// are missing, updates each slide's SlideShowTransition properties, and saves the
// modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, XML, Slide transition, SlideShowTransition
//
// Use Cases:
// - Batch update slide transitions based on external configuration.
// - Automate preparation of presentations for webinars or e‑learning.
// - Integrate transition settings into CI/CD pipelines for slide decks.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Xml;

namespace SlideTransitionImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPresentationPath = "input.pptx";
            string xmlPath = "transitions.xml";
            string outputPresentationPath = "output.pptx";

            try
            {
                // Ensure input presentation exists; create a simple one if missing
                if (!File.Exists(inputPresentationPath))
                {
                    Aspose.Slides.Presentation tempPres = new Aspose.Slides.Presentation();
                    // Add two additional empty slides (total 3 slides)
                    Aspose.Slides.ILayoutSlide layout = tempPres.Slides[0].LayoutSlide;
                    tempPres.Slides.AddEmptySlide(layout);
                    tempPres.Slides.AddEmptySlide(layout);
                    tempPres.Save(inputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    tempPres.Dispose();
                }

                // Ensure XML file exists; create a sample if missing
                if (!File.Exists(xmlPath))
                {
                    XmlDocument sampleDoc = new XmlDocument();
                    XmlElement root = sampleDoc.CreateElement("Transitions");
                    sampleDoc.AppendChild(root);
                    for (int i = 0; i < 3; i++)
                    {
                        XmlElement slideElem = sampleDoc.CreateElement("Slide");
                        slideElem.SetAttribute("index", i.ToString());
                        slideElem.SetAttribute("type", "Fade");
                        slideElem.SetAttribute("time", "2000");
                        root.AppendChild(slideElem);
                    }
                    sampleDoc.Save(xmlPath);
                }

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentationPath);

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
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
