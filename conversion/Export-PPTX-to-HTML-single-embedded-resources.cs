using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputDir = "output";
        var outputHtml = Path.Combine(outputDir, "presentation.html");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                var options = new Aspose.Slides.Export.Html5Options()
                {
                    EmbedImages = true,
                    OutputPath = outputDir
                };

                pres.Save(outputHtml, Aspose.Slides.Export.SaveFormat.Html5, options);
            }
        }
        catch (Exception ex)
        {
            // If the file format is not supported, handle accordingly.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}