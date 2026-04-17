using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define the licensed font to replace all embedded fonts
            Aspose.Slides.IFontData licensedFont = new Aspose.Slides.FontData("YourLicensedFontName");

            // Retrieve all embedded fonts in the presentation
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            // Replace each embedded font with the licensed font
            foreach (Aspose.Slides.IFontData sourceFont in embeddedFonts)
            {
                presentation.FontsManager.ReplaceFont(sourceFont, licensedFont);
            }

            // Save the modified presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported or other processing error
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}