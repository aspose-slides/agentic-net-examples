using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            // Replace all occurrences of "Hello" with "Hi"
            Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "Hello", "Hi", null);
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // If the format is not supported, an exception will be thrown
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}