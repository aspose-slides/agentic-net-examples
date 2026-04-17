using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape that will act as a text box
            IAutoShape textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            textBox.AddTextFrame("Sample Text");

            // Apply diagonal stripe pattern fill with gray foreground
            textBox.FillFormat.FillType = FillType.Pattern;
            textBox.FillFormat.PatternFormat.PatternStyle = PatternStyle.DownwardDiagonal; // closest to diagonal stripe
            textBox.FillFormat.PatternFormat.ForeColor.Color = Color.Gray;
            textBox.FillFormat.PatternFormat.BackColor.Color = Color.White;

            // Save the presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Console.WriteLine(ex.Message);
        }
    }
}