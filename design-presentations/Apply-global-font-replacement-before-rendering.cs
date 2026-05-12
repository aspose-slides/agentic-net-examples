using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths and font names
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string sourceFontName = "Arial";
        string destFontName = "Times New Roman";

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

            // Create font data objects for source and destination fonts
            Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData(sourceFontName);
            Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData(destFontName);

            // Apply global font replacement
            presentation.FontsManager.ReplaceFont(sourceFont, destFont);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported file format
            Console.WriteLine("File format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., loading errors, rendering issues)
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}