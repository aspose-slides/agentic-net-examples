using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths and font names
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string sourceFontName = "Arial";
        string destFontName = "Times New Roman";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define source and destination fonts
            Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData(sourceFontName);
            Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData(destFontName);

            // Replace font across the presentation while preserving formatting
            presentation.FontsManager.ReplaceFont(sourceFont, destFont);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}