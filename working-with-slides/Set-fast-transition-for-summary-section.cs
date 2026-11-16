// -----------------------------------------------------------------------------
// Example: Set Fast Transition for Summary Section in PowerPoint using C#
// 
// Description:
// This console application creates or loads a PPTX file, applies a fast slide
// transition (Fade) to all slides representing a summary section, and saves the
// modified presentation. It demonstrates using Aspose.Slides for .NET to
// automate transition settings in PowerPoint files.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide transition, fast transition
// 
// Use Cases:
// - Automating slide transition configuration for summary sections in presentations.
// - Ensuring consistent fast transitions across multiple slides in batch processing.
// - Integrating transition settings into .NET presentation generation workflows.
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

        try
        {
            // Ensure input file exists; create a simple presentation if missing.
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation newPres = new Aspose.Slides.Presentation();
                // Add a few slides to simulate a summary section.
                newPres.Slides.AddClone(newPres.Slides[0]);
                newPres.Slides.AddClone(newPres.Slides[0]);
                newPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                newPres.Dispose();
            }

            // Load the presentation.
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Apply a fast transition (Fade) to each slide.
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                pres.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            }

            // Save the modified presentation.
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("Fast transition applied successfully. Output saved to " + outputPath);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred: " + ex.Message);
            return 1;
        }
    }
}
