using System;
using System.IO;
using Aspose.Slides.Export;

namespace FontReplacementExample
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
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get all embedded fonts in the presentation
                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Replace each embedded font with a system font (e.g., Arial)
                foreach (Aspose.Slides.IFontData embeddedFont in embeddedFonts)
                {
                    Aspose.Slides.IFontData sourceFont = embeddedFont;
                    Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Arial");
                    presentation.FontsManager.ReplaceFont(sourceFont, destFont);
                }

                // Save the modified presentation as PDF
                presentation.Save(outputPath, SaveFormat.Pdf);

                // Dispose the presentation object
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}