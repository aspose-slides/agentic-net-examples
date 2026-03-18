using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an ellipse shape
            Aspose.Slides.IShape ellipse = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

            // Apply fill formatting
            Aspose.Slides.IFillFormat fill = ellipse.FillFormat;
            fill.FillType = Aspose.Slides.FillType.Solid;
            fill.SolidFillColor.Color = System.Drawing.Color.LightBlue;

            // Apply line formatting
            Aspose.Slides.ILineFormat line = ellipse.LineFormat;
            line.Width = 5;
            line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            line.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkBlue;

            // Save the presentation
            presentation.Save("EllipsePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}