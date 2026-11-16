// -----------------------------------------------------------------------------
// Example: Apply Fade Transition with 2-Second Auto Advance to All Slides
//
// Description:
// This console program loads an existing PPTX file, sets a Fade slide transition
// with a two‑second automatic advance delay on every slide, and saves the
// modified presentation as a new PPTX file. It creates a sample input file if
// none is found and exits with a non‑zero code on failure.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide transition, fade, auto advance
//
// Use Cases:
// - Preparing presentations with consistent transitions across all slides.
// - Automating slide show timing for timed presentations.
// - Batch processing PPTX files to enforce corporate slide transition standards.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                slide.SlideShowTransition.AdvanceOnClick = false;
                slide.SlideShowTransition.AdvanceAfterTime = 2000u; // 2 seconds
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Transition applied successfully. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
