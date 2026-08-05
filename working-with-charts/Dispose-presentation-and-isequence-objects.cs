// -----------------------------------------------------------------------------
// Example: Dispose presentation and isequence objects using C#
//
// Description:
// Demonstrates how to load a PPTX file, access its first slide animation
// timeline, clear the main ISequence of animation effects, save the modified
// presentation, and properly dispose of the Presentation object using
// Aspose.Slides for .NET. This pattern ensures resources are released and
// animation sequences are managed in automated PowerPoint workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Dispose, Presentation,
// ISequence, Objects, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate disposal of Presentation objects after processing.
// - Manage and clear animation sequences (ISequence) in PPTX files.
// - Build .NET tools for PowerPoint animation handling.
// - Ensure proper resource cleanup in server-side PPTX processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Presentation(inputPath);

            // Access the animation timeline of the first slide
            AnimationTimeLine timeline = (AnimationTimeLine)presentation.Slides[0].Timeline;

            // Get the main sequence (ISequence) from the timeline
            ISequence mainSequence = timeline.MainSequence;

            // Example operation: clear any existing effects in the main sequence
            mainSequence.Clear();

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        // Handle unsupported format exceptions
        catch (PptxUnsupportedFormatException)
        {
            Console.WriteLine("The file format is not supported (PPTX).");
        }
        catch (PptUnsupportedFormatException)
        {
            Console.WriteLine("The file format is not supported (PPT).");
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Dispose of the Presentation to release resources
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
