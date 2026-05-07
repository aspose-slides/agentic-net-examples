using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontEmbeddedSwfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation and custom font paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";
            string fontPath = "customfont.ttf";

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found.");
                return;
            }
            if (!File.Exists(fontPath))
            {
                Console.WriteLine("Custom font file not found.");
                return;
            }

            try
            {
                // Load custom font into Aspose.Slides font cache
                byte[] customFontData = File.ReadAllBytes(fontPath);
                FontsLoader.LoadExternalFont(customFontData);

                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Embed each font used in the presentation (subset only)
                IFontData[] allFonts = presentation.FontsManager.GetFonts();
                if (allFonts != null && allFonts.Length > 0)
                {
                    foreach (IFontData font in allFonts)
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.OnlyUsed);
                    }
                }

                // Configure SWF options (optional settings)
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.DefaultRegularFont = "Arial"; // fallback font if needed

                // Save as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose presentation
                presentation.Dispose();

                // Clear loaded custom fonts from cache
                FontsLoader.ClearCache();

                Console.WriteLine("SWF file created successfully.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // If the exception indicates an unsupported format, the format is not supported.
            }
        }
    }
}