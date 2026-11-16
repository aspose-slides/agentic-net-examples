// -----------------------------------------------------------------------------
// Example: Reset First Slide Number After Removing First Slide
//
// Description:
// This console application demonstrates how to delete the first slide from a
// PowerPoint PPTX file and reset the presentation's first slide number to keep
// correct slide numbering using Aspose.Slides for .NET. It creates a sample PPTX
// if none exists, performs the removal, updates the FirstSlideNumber property,
// and saves the modified file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reset First Slide Number, Slide Removal
//
// Use Cases:
// - Remove an introductory slide and maintain proper slide numbers.
// - Automate slide cleanup in batch PowerPoint processing.
// - Ensure accurate slide numbering after dynamic slide deletions.
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
            // Create a sample presentation if the input file does not exist
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                Aspose.Slides.ILayoutSlide layout = samplePres.Slides[0].LayoutSlide;
                samplePres.Slides.AddEmptySlide(layout);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Remove the first slide
                Aspose.Slides.ISlide firstSlide = pres.Slides[0];
                pres.Slides.Remove(firstSlide);

                // Reset the first slide number to 1
                pres.FirstSlideNumber = 1;

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
