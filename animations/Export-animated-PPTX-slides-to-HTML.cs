using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.html";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var options = new Aspose.Slides.Export.Html5Options
                {
                    AnimateShapes = true,
                    AnimateTransitions = true
                };
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}