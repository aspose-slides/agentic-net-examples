using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputFolder = "InputPresentations";
            string outputFolder = "OutputImages";

            // Verify input directory exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder not found.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string filePath in files)
            {
                // Check if the file exists before processing
                if (!File.Exists(filePath))
                {
                    continue;
                }

                try
                {
                    // Load the presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);

                    // Set up fallback font rules for consistent rendering
                    Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
                    rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                    presentation.FontsManager.FontFallBackRulesCollection = rules;

                    // Convert each slide to PNG
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.IImage image = presentation.Slides[i].GetImage(1f, 1f);
                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + $"_slide{i + 1}.png");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    presentation.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"File format not supported: {filePath}");
                }
                catch (Exception ex)
                {
                    // General error handling
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }
        }
    }
}