using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 150, 50);
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.White;
        shape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
        shape.LineFormat.Width = 2.0;
        shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

        // Retrieve the effective line width
        Aspose.Slides.ILineFormatEffectiveData effectiveLineFormat = shape.LineFormat.GetEffective();
        double effectiveWidth = effectiveLineFormat.Width;
        Console.WriteLine("Effective line width: " + effectiveWidth);

        // Save the presentation
        string outputPath = "Output.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}