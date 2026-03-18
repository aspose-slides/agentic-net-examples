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
            var outputPath = "output.pptx";

            var presentation = new Aspose.Slides.Presentation(inputPath);
            var slide = presentation.Slides[0];
            var shape = slide.Shapes[0];

            var effectiveFill = shape.FillFormat.GetEffective();
            var fillColor = effectiveFill.SolidFillColor; // System.Drawing.Color

            Console.WriteLine("Effective fill color: " + fillColor.ToString());

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}