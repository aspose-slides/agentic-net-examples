using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape to the slide
        Aspose.Slides.IShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 150);

        // Access the fill format of the ellipse
        Aspose.Slides.IFillFormat fillFormat = ellipse.FillFormat;

        // Set the fill type to solid and apply a red color
        fillFormat.FillType = Aspose.Slides.FillType.Solid;
        fillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Save the presentation to a file
        presentation.Save("EllipseFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}