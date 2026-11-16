// -----------------------------------------------------------------------------
// Example: Remove Every Third Slide Using RemoveAt in Aspose.Slides for .NET
//
// Description:
// This console program creates a sample PPTX file if none exists, then loads
// the presentation, removes every third slide using the RemoveAt method, and
// saves the modified presentation. It demonstrates slide manipulation with
// Aspose.Slides for .NET in C#.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, RemoveAt, Every Third Slide
//
// Use Cases:
// - Clean up presentations by deleting periodic placeholder slides.
// - Automate slide trimming in batch processing pipelines.
// - Prepare slide decks for publishing by removing unwanted intervals.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

class Program
{
    static int Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                // Create a sample presentation with 7 slides
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                // Ensure there is at least one layout slide to use
                Aspose.Slides.ILayoutSlide layout = samplePres.Slides[0].LayoutSlide;
                for (int i = 0; i < 6; i++)
                {
                    samplePres.Slides.AddEmptySlide(layout);
                }
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            for (int i = pres.Slides.Count - 1; i >= 0; i--)
            {
                if ((i + 1) % 3 == 0)
                {
                    pres.Slides.RemoveAt(i);
                }
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("Every third slide removed successfully. Output saved to " + outputPath);
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}
