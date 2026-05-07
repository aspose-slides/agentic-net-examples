using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input directory containing PPTX files (default: current directory)
        string inputDir = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

        // Output base directory for generated files
        string outputDir = args.Length > 1 ? args[1] : Path.Combine(Directory.GetCurrentDirectory(), "output");

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Get all PPTX files in the input directory
        string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");

        foreach (string pptxPath in pptxFiles)
        {
            // Verify the file exists
            if (!File.Exists(pptxPath))
            {
                continue;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(pptxPath);

                // Save the whole presentation as PDF
                string pdfPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(pptxPath) + ".pdf");
                pres.Save(pdfPath, SaveFormat.Pdf);

                // Create a subfolder for PNG slides
                string pngFolder = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(pptxPath) + "_png");
                if (!Directory.Exists(pngFolder))
                {
                    Directory.CreateDirectory(pngFolder);
                }

                // Export each slide to a separate PNG file
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    using (IImage image = slide.GetImage())
                    {
                        string pngPath = Path.Combine(pngFolder, $"slide_{i + 1}.png");
                        image.Save(pngPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Dispose the presentation
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions as needed
            }
        }
    }
}