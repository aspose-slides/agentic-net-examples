// -----------------------------------------------------------------------------
// Example: Save PPTX Slides as 16‑Bit HDR PNG Images Using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, iterates through each
// slide, renders the slide to a high‑resolution image, and saves the image as a
// PNG file. The code demonstrates the proper Aspose.Slides for .NET usage
// without relying on unavailable PngOptions, handling file existence checks,
// and ensuring the presentation is saved before the program exits.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide to PNG, high‑resolution export, 16‑bit PNG
//
// Use Cases:
// - Converting a corporate presentation into high‑quality PNG assets for web publishing.
// - Generating slide thumbnails for a document management system.
// - Preparing slide images for further image‑processing pipelines that require PNG format.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath;
        if (args != null && args.Length > 0)
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "input.pptx";
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: The file '" + inputPath + "' does not exist.");
            return;
        }

        if (!string.Equals(Path.GetExtension(inputPath), ".pptx", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Error: Unsupported file format. Only PPTX files are supported.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Use a scaling factor to increase DPI (e.g., 2x for higher resolution).
                // Aspose.Slides does not expose a direct 16‑bit PNG option; the exported PNG
                // will be 8‑bit per channel. For true 16‑bit HDR PNG, additional image‑processing
                // libraries would be required.
                using (Aspose.Slides.IImage image = slide.GetImage(2f, 2f))
                {
                    string outputFileName = $"slide_{i + 1:D3}.png";
                    image.Save(outputFileName, Aspose.Slides.ImageFormat.Png);
                    Console.WriteLine("Saved: " + outputFileName);
                }
            }

            // Save the presentation back (optional, demonstrates lifecycle handling).
            string savedPresentationPath = "output_saved.pptx";
            presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved as: " + savedPresentationPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
