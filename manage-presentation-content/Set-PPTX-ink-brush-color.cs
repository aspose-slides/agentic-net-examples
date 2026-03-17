using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Presentation(inputPath))
            {
                var slide = presentation.Slides[0];
                var ink = slide.Shapes[0] as IInk;

                if (ink != null && ink.Traces.Length > 0)
                {
                    var brush = ink.Traces[0].Brush;
                    brush.Color = Color.Blue;

                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
                else
                {
                    Console.WriteLine("Ink shape not found on the first slide.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}