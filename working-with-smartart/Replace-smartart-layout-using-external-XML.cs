using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace ReplaceSmartArtLayout
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string presentationPath = "input.pptx";
            string xmlConfigPath = "layoutConfig.xml";
            string outputPath = "output.pptx";

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Verify that the XML configuration file exists
            if (!File.Exists(xmlConfigPath))
            {
                Console.WriteLine("XML configuration file not found: " + xmlConfigPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Get the first slide (or any slide you need)
                    ISlide slide = pres.Slides[0];

                    // Find the first SmartArt shape on the slide
                    Aspose.Slides.SmartArt.SmartArt smartArt = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        smartArt = shape as Aspose.Slides.SmartArt.SmartArt;
                        if (smartArt != null)
                        {
                            break;
                        }
                    }

                    if (smartArt == null)
                    {
                        Console.WriteLine("No SmartArt shape found on the first slide.");
                        return;
                    }

                    // Load the custom layout type from the XML configuration
                    XDocument xmlDoc = XDocument.Load(xmlConfigPath);
                    // Expecting an element like <Layout>BasicBlockList</Layout>
                    XElement layoutElement = xmlDoc.Root.Element("Layout");
                    if (layoutElement == null)
                    {
                        Console.WriteLine("Invalid XML configuration: missing <Layout> element.");
                        return;
                    }

                    string layoutName = layoutElement.Value.Trim();

                    // Parse the layout name to SmartArtLayoutType enum
                    SmartArtLayoutType newLayout;
                    try
                    {
                        newLayout = (SmartArtLayoutType)Enum.Parse(typeof(SmartArtLayoutType), layoutName);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid layout name in XML: " + layoutName);
                        return;
                    }

                    // Replace the existing layout with the new layout
                    smartArt.Layout = newLayout;

                    // Save the modified presentation
                    try
                    {
                        pres.Save(outputPath, SaveFormat.Pptx);
                        Console.WriteLine("Presentation saved successfully to " + outputPath);
                    }
                    catch (Exception saveEx)
                    {
                        // Format not supported or other save errors
                        // format not supported
                        Console.WriteLine("Error saving presentation: " + saveEx.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., loading issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}