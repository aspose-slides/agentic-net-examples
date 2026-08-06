// -----------------------------------------------------------------------------
// Example: Replace smartart layout using custom XML using C#
//
// Description:
// Demonstrates how to replace a SmartArt layout with a custom layout using
// custom XML in a PowerPoint presentation with Aspose.Slides for .NET. The
// example loads an existing PPTX file, reads a custom layout definition from
// an XML file (placeholder for actual API usage), locates the first SmartArt
// shape on the first slide, sets its layout to Custom, and saves the result.
// This pattern can be used to automate SmartArt layout transformations in
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Custom Layout, XML,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of SmartArt layouts using custom XML definitions.
// - Build .NET tools for PowerPoint presentation customization.
// - Integrate SmartArt layout manipulation into document generation pipelines.
// - Validate and test SmartArt transformations before deployment.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace ReplaceSmartArtLayout
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationPath = "input.pptx";
            string customLayoutXmlPath = "customLayout.xml";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(customLayoutXmlPath))
            {
                Console.WriteLine("Custom layout XML file not found: " + customLayoutXmlPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Read custom layout XML (placeholder - actual processing depends on API)
                    string customLayoutXml = File.ReadAllText(customLayoutXmlPath);
                    // TODO: Apply custom layout XML to SmartArt if API supports it

                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Find the first SmartArt shape on the slide
                    ISmartArt smartArt = null;
                    for (int i = 0; i < slide.Shapes.Count; i++)
                    {
                        ISmartArt candidate = slide.Shapes[i] as ISmartArt;
                        if (candidate != null)
                        {
                            smartArt = candidate;
                            break;
                        }
                    }

                    if (smartArt != null)
                    {
                        // Replace the layout with a custom layout
                        smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.Custom;
                    }
                    else
                    {
                        Console.WriteLine("No SmartArt shape found on the first slide.");
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
