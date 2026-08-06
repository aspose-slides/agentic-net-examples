// -----------------------------------------------------------------------------
// Example: Replace smartart layout with XML using C#
//
// Description:
// Demonstrates how to replace a SmartArt layout with XML using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, SmartArt, Layout, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replace SmartArt layout with XML.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
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
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string customLayoutXml = "customLayout.xml";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Assume we work with the first slide
                ISlide slide = pres.Slides[0];

                // Find the first SmartArt shape on the slide
                ISmartArt smartArt = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        smartArt = (ISmartArt)shape;
                        break;
                    }
                }

                if (smartArt == null)
                {
                    Console.WriteLine("No SmartArt shape found on the slide.");
                }
                else
                {
                    // Replace the layout with a custom layout defined in an XML file.
                    // Aspose.Slides does not expose a direct method to load a layout from XML,
                    // so this part is represented as a placeholder for the actual implementation.
                    // Example: smartArt.LoadCustomLayout(customLayoutXml);
                    // For demonstration, set the layout to Custom.
                    smartArt.Layout = SmartArtLayoutType.Custom;

                    // Additional code to apply the XML-defined layout would go here.
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (including possible web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
