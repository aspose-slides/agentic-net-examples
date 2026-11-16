// -----------------------------------------------------------------------------
// Example: Convert All Slides to PNG Using foreach Loop
//
// Description:
// This console application loads a PowerPoint PPTX file, creates it if missing,
// iterates through each slide using a foreach loop, and exports each slide as a
// PNG image. It demonstrates Aspose.Slides for .NET slide conversion and file
// handling in C#.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide to PNG, foreach loop
//
// Use Cases:
// - Automate batch conversion of presentations to images for web thumbnails.
// - Generate slide images for reporting or documentation pipelines.
// - Integrate slide export functionality into .NET backend services.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.pptx");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // If input file does not exist, create a simple presentation
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation tempPres = new Aspose.Slides.Presentation();
                // Add a blank slide
                tempPres.Slides.AddEmptySlide(tempPres.Slides[0].LayoutSlide);
                tempPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                tempPres.Dispose();
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            int slideIndex = 0;
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                using (Aspose.Slides.IImage image = slide.GetImage())
                {
                    string outPath = Path.Combine(outputDir, $"slide_{slideIndex}.png");
                    image.Save(outPath, Aspose.Slides.ImageFormat.Png);
                }
                slideIndex++;
            }

            // Save (optional, no changes made)
            pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("All slides have been exported to PNG successfully.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}
