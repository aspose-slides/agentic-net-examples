using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";

        string inputPath = Path.Combine(Environment.CurrentDirectory, inputFile);
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        var layoutSlides = pres.Masters[0].LayoutSlides;
        var newLayout = layoutSlides.Add(Aspose.Slides.SlideLayoutType.Blank, null);

        try
        {
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}