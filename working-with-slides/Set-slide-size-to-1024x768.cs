// -----------------------------------------------------------------------------
// Example: Set Slide Size to 1024x768 Points in PowerPoint Presentation
//
// Description:
// This console application loads an existing PPTX file (or creates a sample one
// if missing), sets the slide size to 1024x768 points using Aspose.Slides for .NET,
// and saves the modified presentation. It includes basic error handling for
// missing files and unsupported formats.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide size, set dimensions
//
// Use Cases:
// - Adjust slide dimensions for custom display resolutions
// - Prepare presentation for printing on specific paper size
// - Standardize slide size across multiple presentations
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        int exitCode = 0;
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
                Console.WriteLine("Sample input file created: " + inputPath);
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            presentation.SlideSize.SetSize(1024f, 768f, Aspose.Slides.SlideSizeScaleType.EnsureFit);
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Slide size set to 1024x768 points and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
            exitCode = 1;
        }

        return exitCode;
    }
}
