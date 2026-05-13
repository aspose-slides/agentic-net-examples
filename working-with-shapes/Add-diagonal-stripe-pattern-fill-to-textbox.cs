using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddDiagonalStripePatternFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape that will act as a text box
            Aspose.Slides.IAutoShape textBox = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100,   // X position
                100,   // Y position
                300,   // Width
                100);  // Height

            // Add a text frame to the shape
            textBox.AddTextFrame("Sample Text");

            // Apply pattern fill
            textBox.FillFormat.FillType = Aspose.Slides.FillType.Pattern;

            // Set the pattern style to a diagonal stripe (using an existing enum value)
            textBox.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DownwardDiagonal;

            // Set foreground (stripe) color to gray
            textBox.FillFormat.PatternFormat.ForeColor.Color = Color.Gray;

            // Set background color (optional, here set to white)
            textBox.FillFormat.PatternFormat.BackColor.Color = Color.White;

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}