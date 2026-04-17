using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontListingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = "input.pptx";
                var fontPath = "customfont.ttf";
                var outputPath = "output.pptx";

                // Verify input files exist
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Input presentation not found: {inputPath}");
                    return;
                }

                if (!File.Exists(fontPath))
                {
                    Console.WriteLine($"Font file not found: {fontPath}");
                    return;
                }

                // Load font data into memory
                var fontData = File.ReadAllBytes(fontPath);

                // Set up load options with memory‑based font source
                var loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { fontData };

                // Load presentation with the specified load options
                var presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

                // List all font families available in the presentation
                var fonts = presentation.FontsManager.GetFonts();
                Console.WriteLine("Available font families:");
                foreach (var font in fonts)
                {
                    Console.WriteLine(font.FontName);
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}