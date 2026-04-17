using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceEmbeddedFontsToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if the input file exists
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
                    // Get all embedded fonts in the presentation
                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                    // Replace each embedded font with a system font (e.g., Arial)
                    foreach (IFontData embeddedFont in embeddedFonts)
                    {
                        IFontData sourceFont = embeddedFont;
                        IFontData destFont = new FontData("Arial");
                        presentation.FontsManager.ReplaceFont(sourceFont, destFont);
                    }

                    // Save the modified presentation as PDF
                    presentation.Save(outputPath, SaveFormat.Pdf);
                }

                Console.WriteLine("Presentation converted and saved to PDF successfully.");
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
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