using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load custom fonts from a folder if it exists
                string customFontsFolder = "customfonts";
                if (Directory.Exists(customFontsFolder))
                {
                    string[] fontFolders = new string[] { customFontsFolder };
                    Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);
                }

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Add a fallback rule for all Unicode characters to use Arial when a glyph is missing
                Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0000, 0xFFFF, "Arial"));

                // Configure SWF export options (optional settings can be adjusted here)
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                swfOptions.ViewerIncluded = true; // include the viewer in the SWF

                // Save the presentation as SWF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Save the (potentially modified) presentation before exiting
                presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up resources
                presentation.Dispose();
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported file format
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}