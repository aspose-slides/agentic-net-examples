// -----------------------------------------------------------------------------
// Example: Convert PowerPoint to GIF with Desired Quality (90%) using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, converts it to an animated GIF
// using Aspose.Slides for .NET, and demonstrates that GIF quality cannot be
// directly set via the API. The example includes file existence checks and
// basic error handling, suitable for automating PPTX workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, GIF conversion, quality
//
// Use Cases:
// - Automate conversion of presentations to GIFs for web previews.
// - Generate GIFs for email attachments or documentation.
// - Integrate slide export into CI/CD pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

        if (!System.IO.File.Exists(inputPath))
        {
            System.Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();

            // Note: Aspose.Slides does not provide a direct quality setting for GIF.
            // GIF uses lossless compression; quality adjustments are not applicable.
            // Adjust frame size or other options to influence file size if needed.
            gifOptions.FrameSize = new System.Drawing.Size(800, 600);
            gifOptions.DefaultDelay = 100; // delay in hundredths of a second
            gifOptions.TransitionFps = 10;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
            presentation.Dispose();

            System.Console.WriteLine("Presentation saved as GIF to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
