// -----------------------------------------------------------------------------
// Example: Compress and Remove Unused Layout Slides from PowerPoint Presentation
//
// Description:
// This console application loads an existing PPTX file, removes any layout
// slides that are not referenced by presentation slides using Aspose.Slides
// LowCode compression utilities, and saves the optimized file. It creates a
// sample presentation if the input file is missing, demonstrating how to
// reduce PPTX size and improve performance in automated workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, layout compression, remove unused layouts
//
// Use Cases:
// - Reduce PPTX file size before distribution
// - Optimize presentations in batch processing pipelines
// - Clean up unused master and layout slides in generated presentations
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        if (!File.Exists(inputPath))
        {
            // Create a sample presentation with a single slide
            Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
            // Add an empty slide using the default layout
            samplePresentation.Slides.AddEmptySlide(samplePresentation.Slides[0].LayoutSlide);
            samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            samplePresentation.Dispose();
            Console.WriteLine("Sample input presentation created at: " + inputPath);
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            // Remove unused layout slides
            Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
            // Optionally remove unused master slides
            Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
            Console.WriteLine("Compressed presentation saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error during compression: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
