// -----------------------------------------------------------------------------
// Example: Clone Slide into Middle and Apply Fade Transition with 4-Second Advance
//
// Description:
// This console application loads an existing PPTX file, clones the first slide,
// inserts the cloned slide into the middle of the presentation, and configures
// a fade transition that advances automatically after 4 seconds. The modified
// presentation is saved as a new PPTX file. Useful for automating slide
// duplication and transition customization in PowerPoint workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, clone slide, slide transition, fade, advance time
//
// Use Cases:
// - Duplicate a slide to maintain consistent layout while adding custom transitions.
// - Insert a cloned slide at a specific position for dynamic presentation generation.
// - Automate transition settings for timed slide shows in corporate presentations.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Clone the first slide
            Aspose.Slides.ISlide sourceSlide = pres.Slides[0];

            // Calculate middle index
            int middleIndex = pres.Slides.Count / 2;

            // Insert the cloned slide at the middle position
            Aspose.Slides.ISlide clonedSlide = pres.Slides.InsertClone(middleIndex, sourceSlide);

            // Configure fade transition with a 4‑second automatic advance
            clonedSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            clonedSlide.SlideShowTransition.AdvanceOnClick = true;
            clonedSlide.SlideShowTransition.AdvanceAfterTime = 4000U; // time in milliseconds

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
