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
                Console.WriteLine("Input presentation file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(fontPath))
            {
                Console.WriteLine("Custom font file does not exist: " + fontPath);
                return;
            }

            try
            {
                // Load custom font into Aspose.Slides font loader
                byte[] fontData = File.ReadAllBytes(fontPath);
                FontsLoader.LoadExternalFont(fontData);

                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Embed the custom font subset (only used characters) into the presentation
                    presentation.FontsManager.AddEmbeddedFont(fontData, EmbedFontCharacters.OnlyUsed);

                    // Configure SWF options (optional settings can be adjusted here)
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.DefaultRegularFont = "CustomFont"; // fallback font name if needed

                    // Save presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                // Clear loaded custom fonts from cache
                FontsLoader.ClearCache();

                Console.WriteLine("SWF file created successfully: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}