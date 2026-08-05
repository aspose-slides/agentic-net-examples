// -----------------------------------------------------------------------------
// Example: Load pptx and get first slide using C#
//
// Description:
// Demonstrates how to load a PPTX file, access its first slide, apply a simple
// transition, and save the modified presentation using C# and Aspose.Slides for
// .NET. The example shows the essential steps for loading, processing, and
// persisting PowerPoint files in a standalone console application. Developers
// can use this pattern to automate PPTX workflows, add slide effects, or integrate
// presentation logic into .NET solutions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, First Slide, Transition,
// Save, Presentation Processing, Office Automation
//
// Use Cases:
// - Load a PPTX file and retrieve the first slide for further processing.
// - Apply slide transitions programmatically.
// - Build C# tools for PowerPoint presentation automation.
// - Generate or modify PPTX files in .NET applications.
// - Validate and test presentation workflows before deployment.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation from the specified file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide for processing
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Example processing: set a simple transition on the first slide
            firstSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            firstSlide.SlideShowTransition.AdvanceOnClick = true;
            firstSlide.SlideShowTransition.AdvanceAfterTime = 2000; // 2 seconds

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
