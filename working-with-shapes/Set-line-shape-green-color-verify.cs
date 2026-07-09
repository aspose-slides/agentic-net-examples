using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                var slide = pres.Slides[0];
                var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50, 300, 0);
                line.LineFormat.Width = 5;
                line.LineFormat.FillFormat.FillType = FillType.Solid;
                line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;

                var effective = line.LineFormat.GetEffective();
                var effectiveColor = effective.FillFormat.SolidFillColor;
                Console.WriteLine("Effective line color: " + effectiveColor.ToString());

                pres.Save("LineColorExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}