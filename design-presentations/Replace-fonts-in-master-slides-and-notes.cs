using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var pres = new Presentation(inputPath))
            {
                // Define font replacement mapping
                var sourceFont = new FontData("Arial");
                var destFont = new FontData("Calibri");

                // Replace fonts in master slides, layouts, notes, and comments
                pres.FontsManager.ReplaceFont(sourceFont, destFont);

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}