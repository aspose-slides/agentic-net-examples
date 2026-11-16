// -----------------------------------------------------------------------------
// Example: Compress and Remove Orphaned Master and Layout Slides in PPTX
//
// Description:
// This console program demonstrates how to load a PowerPoint file, clone a slide
// (including its master) into a new presentation, and then use Aspose.Slides
// LowCode compression utilities to remove unused master and layout slides.
// The result is saved as a compressed PPTX file.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, compress, remove unused masters, layout slides
//
// Use Cases:
// - Reducing file size by eliminating orphaned slide masters after slide manipulation.
// - Preparing presentations for distribution with only necessary resources.
// - Automating cleanup of PPTX files in a batch processing pipeline.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "source.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "compressed.pptx");

        try
        {
            // Ensure source presentation exists; create a simple one if missing.
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation tempPres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = tempPres.Slides[0];
                Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
                tempPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                tempPres.Dispose();
            }

            // Load source presentation.
            Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(inputPath);

            // Create destination presentation and clone the first slide (including its master).
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide clonedSlide = destPres.Slides.AddClone(sourcePres.Slides[0]);

            // Remove unused master and layout slides.
            Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(destPres);
            Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(destPres);

            // Save the compressed presentation.
            destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up.
            sourcePres.Dispose();
            destPres.Dispose();

            Console.WriteLine("Compression completed successfully. Output saved to: " + outputPath);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error during compression: " + ex.Message);
            return 1;
        }
    }
}
