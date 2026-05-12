using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!System.IO.File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var presentation = new Aspose.Slides.Presentation(inputPath);
            var sourceFont = new Aspose.Slides.FontData("Arial");
            var destFont = new Aspose.Slides.FontData("Calibri");
            presentation.FontsManager.ReplaceFont(sourceFont, destFont);
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}