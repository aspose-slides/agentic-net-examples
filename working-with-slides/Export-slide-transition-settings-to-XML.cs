using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string xmlPath = "transitions.xml";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlElement root = xmlDoc.CreateElement("Transitions");
                    xmlDoc.AppendChild(root);

                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        ISlideShowTransition transition = slide.SlideShowTransition;

                        XmlElement slideElem = xmlDoc.CreateElement("Slide");
                        slideElem.SetAttribute("Index", (i + 1).ToString());

                        XmlElement typeElem = xmlDoc.CreateElement("Type");
                        typeElem.InnerText = transition.Type.ToString();
                        slideElem.AppendChild(typeElem);

                        XmlElement advanceOnClickElem = xmlDoc.CreateElement("AdvanceOnClick");
                        advanceOnClickElem.InnerText = transition.AdvanceOnClick.ToString();
                        slideElem.AppendChild(advanceOnClickElem);

                        XmlElement advanceAfterTimeElem = xmlDoc.CreateElement("AdvanceAfterTime");
                        advanceAfterTimeElem.InnerText = transition.AdvanceAfterTime.ToString();
                        slideElem.AppendChild(advanceAfterTimeElem);

                        root.AppendChild(slideElem);
                    }

                    xmlDoc.Save(xmlPath);

                    // Save the (unchanged) presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}