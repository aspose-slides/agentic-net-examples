using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        IShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

        // Set fill to pattern
        shape.FillFormat.FillType = FillType.Pattern;

        // Set pattern style to diagonal lines
        shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.DownwardDiagonal;

        // Set background and foreground colors
        shape.FillFormat.PatternFormat.BackColor.Color = Color.White;
        shape.FillFormat.PatternFormat.ForeColor.Color = Color.Black;

        // Save the presentation
        string outputPath = "PatternEllipse.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}