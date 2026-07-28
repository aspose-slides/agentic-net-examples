// -----------------------------------------------------------------------------
// Example: Apply fallback fonts and export to JPEG using C#
//
// Description:
// Demonstrates how to load external fonts, define font fallback rules, and
// export each slide of a PowerPoint presentation to JPEG images using
// Aspose.Slides for .NET. The example processes all *.pptx files in a given
// directory, saves the modified presentations, and writes JPEG files for each
// slide into a sub‑folder. This pattern can be used to ensure proper font
// rendering and to generate image assets from presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Font Fallback, Export,
// Presentation Processing, Office Automation, Image Generation
//
// Use Cases:
// - Apply font fallback rules to guarantee correct text rendering when the
//   original font is unavailable.
// - Convert PowerPoint slides to JPEG images for web preview or documentation.
// - Automate batch processing of presentations in CI/CD pipelines.
// - Integrate slide‑to‑image conversion into .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputDir;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputDir = args[0];
        }
        else
        {
            inputDir = Directory.GetCurrentDirectory();
        }

        if (!Directory.Exists(inputDir))
        {
            Console.WriteLine("Input directory does not exist: " + inputDir);
            return;
        }

        // Load external fonts if a 'fonts' subfolder exists
        string fontsPath = Path.Combine(inputDir, "fonts");
        if (Directory.Exists(fontsPath))
        {
            string[] fontFolders = new string[] { fontsPath };
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);
        }

        string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");
        foreach (string filePath in pptxFiles)
        {
            try
            {
                using (Presentation pres = new Presentation(filePath))
                {
                    // Apply a simple font fallback rule: if "NonExistingFont" is missing,
                    // fall back to Arial and Times New Roman.
                    var fallbackRule = new FontFallBackRule("NonExistingFont", new string[] { "Arial", "Times New Roman" });
                    pres.FontsManager.FontFallBackRulesCollection.Add(fallbackRule);

                    // Prepare output directories
                    string processedDir = Path.Combine(inputDir, "Processed");
                    if (!Directory.Exists(processedDir))
                    {
                        Directory.CreateDirectory(processedDir);
                    }

                    // Save the modified presentation
                    string outputPptxPath = Path.Combine(processedDir, Path.GetFileName(filePath));
                    pres.Save(outputPptxPath, SaveFormat.Pptx);

                    // Export each slide to JPEG
                    string jpegDir = Path.Combine(processedDir, Path.GetFileNameWithoutExtension(filePath) + "_JPEG");
                    if (!Directory.Exists(jpegDir))
                    {
                        Directory.CreateDirectory(jpegDir);
                    }

                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        using (Bitmap bmp = pres.Slides[i].GetThumbnail(1f, 1f))
                        {
                            string jpegPath = Path.Combine(jpegDir, $"slide_{i + 1}.jpg");
                            bmp.Save(jpegPath, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("File format not supported: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
            }
        }

        // Clear font cache after processing
        Aspose.Slides.FontsLoader.ClearCache();
    }
}
