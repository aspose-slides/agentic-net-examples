using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Define source and destination fonts
                var sourceFont = new Aspose.Slides.FontData("Arial");
                var destFont = new Aspose.Slides.FontData("Calibri");

                // Replace all occurrences of the source font with the destination font
                presentation.FontsManager.ReplaceFont(sourceFont, destFont);

                // Save the updated presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}