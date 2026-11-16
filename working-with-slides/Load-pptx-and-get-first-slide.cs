// -----------------------------------------------------------------------------
// Example: Load PPTX, Access First Slide, Apply Transition, Save Presentation
//
// Description:
// Demonstrates loading a PPTX file, retrieving its first slide, applying a simple
// fade transition, and saving the modified presentation using C# and Aspose.Slides
// for .NET. The program creates a sample input file if none exists and exits with
// a non‑zero code on failure.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load Presentation, First Slide, Transition, Save
//
// Use Cases:
// - Automate slide transition addition to existing presentations.
// - Build command‑line tools for PPTX batch processing.
// - Integrate PowerPoint manipulation into .NET backend services.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Ensure input file exists; create a minimal presentation if missing
        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                return 1;
            }
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Apply a simple fade transition
            firstSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            firstSlide.SlideShowTransition.AdvanceOnClick = true;
            firstSlide.SlideShowTransition.AdvanceAfterTime = 2000; // 2 seconds

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return 1;
        }

        return 0;
    }
}
