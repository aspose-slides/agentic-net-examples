// -----------------------------------------------------------------------------
// Example: Summarize smartart layout types and node counts using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, iterate through its slides,
// identify SmartArt shapes, and output each SmartArt's layout type and node count.
// The example also saves the presentation after processing. This pattern helps
// developers automate PPTX analysis, validate SmartArt usage, or integrate
// presentation insights into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Summarize, SmartArt, Layout,
// Node Count, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of SmartArt layout types and node counts from presentations.
// - Build C# tools for PowerPoint content analysis and reporting.
// - Generate or transform PPTX files while preserving existing content.
// - Validate SmartArt structures before publishing or further processing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other loading errors
            // Format not supported
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Iterate through slides and SmartArt shapes
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    Aspose.Slides.SmartArt.SmartArtLayoutType layout = smartArt.Layout;
                    int nodeCount = smartArt.AllNodes.Count;
                    Console.WriteLine(string.Format("Slide {0}: SmartArt Layout = {1}, Node Count = {2}", slideIndex + 1, layout, nodeCount));
                }
            }
        }

        try
        {
            // Save the presentation before exit
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
