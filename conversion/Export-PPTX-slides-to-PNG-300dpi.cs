using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPng300Dpi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Scale factor to achieve 300 DPI (default DPI is 96)
                    float scale = 300f / 96f;

                    // Export each slide as a high‑resolution PNG
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        string outputPath = Path.Combine(
                            Path.GetDirectoryName(inputPath),
                            $"slide_{i + 1}.png");

                        using (IImage image = slide.GetImage(scale, scale))
                        {
                            image.Save(outputPath, ImageFormat.Png);
                        }
                    }

                    // Save the presentation (no changes made, but required by lifecycle rule)
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (System.Net.WebException)
            {
                // Handle external URL or web service errors
                Console.WriteLine("A network error occurred while accessing external resources.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}