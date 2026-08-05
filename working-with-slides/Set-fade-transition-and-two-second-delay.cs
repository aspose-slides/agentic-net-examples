// -----------------------------------------------------------------------------
// Example: Set fade transition and two second delay using C#
//
// Description:
// Demonstrates how to apply a Fade slide transition with a two‑second automatic
// advance delay to every slide in a PowerPoint presentation using Aspose.Slides
// for .NET. The example loads an existing PPTX file, updates the transition
// settings, and saves the result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fade, Transition, Two Second Delay,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying Fade transitions with a fixed delay to all slides.
// - Build .NET tools for batch processing of PowerPoint presentations.
// - Generate or modify PPTX files programmatically.
// - Validate slide transition settings before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Apply Fade transition with a 2‑second delay to every slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    presentation.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                    presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[i].SlideShowTransition.AdvanceAfterTime = 2000; // 2000 ms = 2 seconds
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
