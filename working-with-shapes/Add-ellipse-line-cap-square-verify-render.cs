using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add an ellipse shape to the slide
        IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);

        // Set the line cap style to square
        ellipse.LineFormat.CapStyle = LineCapStyle.Square;

        // Set line width and color to make the cap visible
        ellipse.LineFormat.Width = 5;
        ellipse.LineFormat.FillFormat.FillType = FillType.Solid;
        ellipse.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

        // Save the presentation
        string outputPath = "EllipseLineCapSquare.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}