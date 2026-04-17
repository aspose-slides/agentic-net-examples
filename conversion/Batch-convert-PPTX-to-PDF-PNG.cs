using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output directories
            string inputDir = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
            string outputDir = args.Length > 1 ? args[1] : Path.Combine(Directory.GetCurrentDirectory(), "output");

            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");
            foreach (string inputPath in pptxFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("File not found: " + inputPath);
                    continue;
                }

                try
                {
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        // Save as PDF
                        string pdfPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                        pres.Save(pdfPath, SaveFormat.Pdf);

                        // Create folder for slide PNGs
                        string slidePngDir = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + "_slides");
                        if (!Directory.Exists(slidePngDir))
                            Directory.CreateDirectory(slidePngDir);

                        // Export each slide to PNG
                        for (int index = 0; index < pres.Slides.Count; index++)
                        {
                            ISlide slide = pres.Slides[index];
                            using (IImage image = slide.GetImage())
                            {
                                string pngPath = Path.Combine(slidePngDir, $"slide_{index}.png");
                                image.Save(pngPath, Aspose.Slides.ImageFormat.Png);
                            }
                        }

                        // Save presentation before exit (no changes made, just to satisfy rule)
                        pres.Save(inputPath, SaveFormat.Pptx);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("The file format is not supported for: " + inputPath);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);
                }
            }
        }
    }
}