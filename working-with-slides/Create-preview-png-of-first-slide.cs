// -----------------------------------------------------------------------------
// Example: Create Preview PNG of First Slide Using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint presentation, generates a PNG
// preview image of the first slide, and saves it to disk. It demonstrates the
// use of Aspose.Slides for .NET to export slide thumbnails, handling missing
// input files by creating a sample presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide preview, PNG export
//
// Use Cases:
// - Automate generation of slide thumbnails for documentation.
// - Validate presentation content by visual inspection of first slide.
// - Integrate slide preview generation into a larger .NET workflow.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories and file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "first_slide.png");

            // Ensure input presentation exists; create a sample if missing
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                // Add a rectangle shape to make the slide visible
                Aspose.Slides.IAutoShape rect = samplePres.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 150);
                rect.TextFrame.Text = "Sample Slide";
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            Aspose.Slides.ISlide firstSlide = pres.Slides[0];

            // Export the slide as PNG image
            using (Aspose.Slides.IImage slideImage = firstSlide.GetImage())
            {
                slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
            }

            // Clean up
            pres.Dispose();

            Console.WriteLine("Preview PNG of the first slide saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
