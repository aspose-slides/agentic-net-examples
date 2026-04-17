using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "source.pptx";
        string outputPath = "cloned_output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlideCollection slides = pres.Slides;
            // Clone the first slide (assumed to contain a flash object) to the end of the collection
            slides.AddClone(slides[0]);
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access, loading errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}