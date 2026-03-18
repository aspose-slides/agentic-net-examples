using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputSvgPath = "slide_1.svg";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Export the first slide as SVG
                using (var fileStream = File.Create(outputSvgPath))
                {
                    presentation.Slides[0].WriteAsSvg(fileStream);
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}