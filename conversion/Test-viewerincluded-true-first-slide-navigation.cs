using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.swf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var pres = new Presentation(inputPath))
            {
                var options = new SwfOptions();
                options.ViewerIncluded = true;

                pres.Save(outputPath, SaveFormat.Swf, options);
            }
        }
        catch (Exception ex) when (ex is NotSupportedException)
        {
            // Format not supported
        }
    }
}