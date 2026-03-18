using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            using (var pres = new Aspose.Slides.Presentation(presentationPath))
            {
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    var slide = pres.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        var shape = slide.Shapes[j];
                        var fill = shape.FillFormat;
                        if (fill != null)
                        {
                            var effective = fill.GetEffective();
                            Console.WriteLine($"Slide {i + 1}, Shape {j + 1}: FillType = {effective.FillType}");
                            if (effective.FillType == Aspose.Slides.FillType.Solid)
                            {
                                Console.WriteLine($"  Solid color: {effective.SolidFillColor}");
                            }
                        }
                    }
                }
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}