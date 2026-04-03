using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var presentation = new Aspose.Slides.Presentation(inputPath);
            using (var animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
            {
                // Set default delay for entrance animations to 2 seconds (2000 ms)
                animationsGenerator.DefaultDelay = 2000;
                animationsGenerator.Run(presentation.Slides);
            }
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}