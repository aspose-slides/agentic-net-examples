// -----------------------------------------------------------------------------
// Example: Remove hidden slides from presentation using C#
//
// Description:
// Demonstrates how to remove hidden slides from a presentation using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Hidden, Slides, 
// Presentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of hidden slides from a presentation.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Collect hidden slides
            List<ISlide> slidesToRemove = new List<ISlide>();
            foreach (ISlide slide in presentation.Slides)
            {
                if (slide.Hidden)
                {
                    slidesToRemove.Add(slide);
                }
            }

            // Remove hidden slides
            foreach (ISlide slide in slidesToRemove)
            {
                slide.Remove();
            }

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
        }
    }
}
