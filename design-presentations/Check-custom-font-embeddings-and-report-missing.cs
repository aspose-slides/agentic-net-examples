using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CheckCustomFontEmbeddings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            var presentationPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"File not found: {presentationPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (var presentation = new Presentation(presentationPath))
                {
                    // Retrieve all fonts used in the presentation
                    var allFonts = presentation.FontsManager.GetFonts();

                    // Retrieve fonts that are already embedded
                    var embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                    // Find fonts that are not embedded
                    var missingFonts = allFonts
                        .Where(font => !embeddedFonts.Any(emb => string.Equals(emb.FontName, font.FontName, StringComparison.OrdinalIgnoreCase)))
                        .Select(font => font.FontName)
                        .Distinct()
                        .ToList();

                    if (missingFonts.Any())
                    {
                        Console.WriteLine("The following fonts are used but not embedded:");
                        foreach (var fontName in missingFonts)
                        {
                            Console.WriteLine($"- {fontName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("All custom fonts are embedded.");
                    }

                    // Save the presentation before exiting
                    presentation.Save(presentationPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}