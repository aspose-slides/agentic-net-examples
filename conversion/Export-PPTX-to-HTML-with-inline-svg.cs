using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.html";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                var htmlOptions = new Aspose.Slides.Export.HtmlOptions();
                var svgOptions = new Aspose.Slides.Export.SVGOptions();
                htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Svg(svgOptions);

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, htmlOptions);

                // Save presentation before exit (optional)
                pres.Save("temp.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}