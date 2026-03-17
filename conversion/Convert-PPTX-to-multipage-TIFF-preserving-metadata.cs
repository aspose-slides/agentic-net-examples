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
            var outputPath = "output.tiff";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var options = new Aspose.Slides.Export.TiffOptions();
                options.ShowHiddenSlides = true;
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}