using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontMappingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_mapped.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Fonts to be replaced
                    string[] originalFonts = new string[] { "Arial", "Calibri", "Times New Roman" };
                    // Replacement font
                    string replacementFontName = "MyCustomFont";

                    // Create destination font data once
                    IFontData replacementFont = new FontData(replacementFontName);

                    // Replace each original font with the replacement font
                    foreach (string originalFontName in originalFonts)
                    {
                        IFontData sourceFont = new FontData(originalFontName);
                        presentation.FontsManager.ReplaceFont(sourceFont, replacementFont);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}