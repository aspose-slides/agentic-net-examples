// -----------------------------------------------------------------------------
// Example: Add uniform slide transition three seconds using C#
//
// Description:
// Demonstrates how to add a uniform Fade slide transition with a three‑second
// duration to every slide in a PowerPoint presentation using C# and Aspose.Slides
// for .NET. The example loads an existing PPTX file, applies the transition to
// all slides, and saves the modified presentation. This pattern can be used to
// automate slide‑show timing adjustments in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Uniform, Slide, Transition, Fade,
// Three, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a uniform Fade transition of three seconds to all slides.
// - Build C# tools for PowerPoint presentation processing and timing control.
// - Generate or modify PPTX files in .NET applications with consistent slide
//   transitions.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Apply a uniform Fade transition with a 3-second duration to all slides
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                presentation.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                presentation.Slides[i].SlideShowTransition.Duration = 3000; // duration in milliseconds
                presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL or I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
