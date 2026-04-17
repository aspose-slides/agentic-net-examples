using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.xps";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            presentation.SlideSize.Orientation = Aspose.Slides.SlideOrientation.Landscape;
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}