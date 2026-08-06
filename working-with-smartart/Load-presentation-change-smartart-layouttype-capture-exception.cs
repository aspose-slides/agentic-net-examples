// -----------------------------------------------------------------------------
// Example: Load presentation change smartart layouttype capture exception using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, iterate through its
// shapes, change the layout type of any SmartArt objects to
// BasicProcess, and capture exceptions that may occur during loading,
// layout modification, or saving using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Change,
// SmartArt, Layout, Exception Handling, Presentation Processing, Office Automation
//
// Use Cases:
// - Load a PPTX file and safely modify SmartArt layout types.
// - Build robust C# tools that handle errors when processing SmartArt in presentations.
// - Automate PPTX transformations while ensuring graceful failure handling.
// - Validate and update SmartArt structures in batch processing scenarios.
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

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        Aspose.Slides.ISlide slide = presentation.Slides[0];
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.ISmartArt)
            {
                Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                try
                {
                    smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess;
                }
                catch (Exception ex)
                {
                    // Property might be read‑only
                    Console.WriteLine("Failed to change layout: " + ex.Message);
                }
            }
        }

        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }

        presentation.Dispose();
    }
}
