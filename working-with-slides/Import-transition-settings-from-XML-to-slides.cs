using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ImportTransitionSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input files
            string presentationPath = "input.pptx";
            string xmlPath = "transitions.xml";

            // Verify files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"Presentation file not found: {presentationPath}");
                return;
            }

            if (!File.Exists(xmlPath))
            {
                Console.WriteLine($"XML file not found: {xmlPath}");
                return;
            }

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Load XML with transition settings
                    XDocument xmlDoc = XDocument.Load(xmlPath);

                    // Expected XML format:
                    // <Transitions>
                    //   <Slide Index="1">
                    //     <Type>Circle</Type>
                    //     <Duration>3000</Duration>
                    //   </Slide>
                    //   ...
                    // </Transitions>

                    foreach (XElement slideElement in xmlDoc.Root.Elements("Slide"))
                    {
                        XAttribute indexAttr = slideElement.Attribute("Index");
                        if (indexAttr == null) continue;

                        int slideIndex;
                        if (!int.TryParse(indexAttr.Value, out slideIndex)) continue;

                        // Slides collection is zero‑based
                        if (slideIndex < 1 || slideIndex > presentation.Slides.Count) continue;

                        ISlideShowTransition transition = presentation.Slides[slideIndex - 1].SlideShowTransition;

                        // Apply transition type if present
                        XElement typeElement = slideElement.Element("Type");
                        if (typeElement != null)
                        {
                            Aspose.Slides.SlideShow.TransitionType parsedType;
                            if (Enum.TryParse(typeElement.Value, out parsedType))
                            {
                                transition.Type = parsedType;
                            }
                        }

                        // Apply duration if present
                        XElement durationElement = slideElement.Element("Duration");
                        if (durationElement != null)
                        {
                            int durationMs;
                            if (int.TryParse(durationElement.Value, out durationMs))
                            {
                                transition.Duration = durationMs;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            // Handle unsupported format exception
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}