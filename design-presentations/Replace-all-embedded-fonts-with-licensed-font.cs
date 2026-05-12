using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontReplacementUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Licensed font name to replace all embedded fonts with
            string licensedFontName = "MyLicensedFont";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported format if needed
                return;
            }

            // Create destination font data (licensed font)
            Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData(licensedFontName);

            // Get all embedded fonts in the presentation
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            // Replace each embedded font with the licensed font
            if (embeddedFonts != null && embeddedFonts.Length > 0)
            {
                foreach (Aspose.Slides.IFontData sourceFont in embeddedFonts)
                {
                    presentation.FontsManager.ReplaceFont(sourceFont, destFont);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose presentation
            presentation.Dispose();

            Console.WriteLine("Font replacement completed. Saved to: " + outputPath);
        }
    }
}