// -----------------------------------------------------------------------------
// Example: Set Slide Size to Custom 16:9 Aspect Ratio
//
// Description:
// This console application loads an existing PPTX file, sets the presentation's
// slide size to a custom 960x540 point dimension (16:9 aspect ratio) without
// scaling the existing content, and saves the modified file. It demonstrates
// using Aspose.Slides for .NET to automate slide‑size adjustments.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide size, custom aspect ratio
//
// Use Cases:
// - Adjust slide dimensions for widescreen presentations
// - Prepare slides for video export
// - Standardize slide size across multiple decks
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            // Ensure input file exists; create a sample if missing
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                samplePres.Slides.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Set custom slide size to 960x540 points (16:9) without scaling content
            presentation.SlideSize.SetSize(960, 540, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Slide size updated successfully. Saved to " + outputPath);
            Environment.Exit(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
