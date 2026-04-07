using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ListRemoveDuplicateCompressEmbeddedFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // List all embedded fonts
                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
                    Console.WriteLine("Embedded fonts before processing:");
                    foreach (IFontData font in embeddedFonts)
                    {
                        Console.WriteLine("- " + font.FontName);
                    }

                    // Remove duplicate fonts (keep one instance per font name)
                    var distinctFonts = embeddedFonts
                        .GroupBy(f => f.FontName)
                        .Select(g => g.First())
                        .ToArray();

                    // Remove all currently embedded fonts
                    foreach (IFontData font in embeddedFonts)
                    {
                        presentation.FontsManager.RemoveEmbeddedFont(font);
                    }

                    // Re‑embed each distinct font with compression (OnlyUsed characters)
                    foreach (IFontData font in distinctFonts)
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.OnlyUsed);
                    }

                    // List embedded fonts after processing
                    IFontData[] finalEmbeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
                    Console.WriteLine("Embedded fonts after processing:");
                    foreach (IFontData font in finalEmbeddedFonts)
                    {
                        Console.WriteLine("- " + font.FontName);
                    }

                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}