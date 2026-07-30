// -----------------------------------------------------------------------------
// Example: Save PPTX slides as PNG 16bit HDR using C#
//
// Description:
// Demonstrates how to save each slide of a PPTX presentation as a 16‑bit per
// channel HDR PNG image using C# and Aspose.Slides for .NET. The example loads a
// PowerPoint file, renders every slide to an image, and writes the images to
// PNG files with 16‑bit colour depth. It also shows the minimal presentation
// lifecycle handling required by Aspose.Slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Save, Pptx, Slides, 16Bit,
// HDR, Image Export, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of PPTX slides to high‑quality 16‑bit HDR PNG images.
// - Build .NET tools for PowerPoint presentation processing with lossless output.
// - Generate or transform PPTX files in .NET applications while preserving colour depth.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SaveSlidesAsPng16BitHdr
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure PNG export options for 16‑bit per channel HDR output
                    PngOptions pngOptions = new PngOptions
                    {
                        // 16‑bit per channel (48‑bit RGB) HDR format
                        PixelFormat = PngPixelFormat.Rgb48bpp,
                        // Optional: best compression while preserving quality
                        CompressionLevel = PngCompressionLevel.BestCompression
                    };

                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        // Render slide to image with default scaling (full size)
                        using (IImage slideImage = slide.GetImage(1f, 1f))
                        {
                            string outputPath = $"slide_{index}.png";
                            slideImage.Save(outputPath, pngOptions);
                        }
                    }

                    // Save the presentation (no modifications, but required by lifecycle rule)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network errors if loading from URL)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
