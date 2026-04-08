using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
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
            Presentation pres = new Presentation(inputPath);

            // Define the source font to replace and the destination font
            IFontData sourceFont = new FontData("Calibri");
            IFontData destFont = new FontData("Arial");

            // Replace the source font with the destination font across the presentation
            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            // Save the updated presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up resources
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}