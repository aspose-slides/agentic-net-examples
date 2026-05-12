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
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define the source font to replace and the destination custom font
            Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
            Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Calibri");

            // Replace all occurrences of the source font with the custom font
            presentation.FontsManager.ReplaceFont(sourceFont, destFont);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}