using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a text box shape
                IAutoShape textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
                textBox.AddTextFrame("Sample Text");

                // Set the fill type to Pattern
                textBox.FillFormat.FillType = FillType.Pattern;

                // Configure the pattern fill
                textBox.FillFormat.PatternFormat.PatternStyle = PatternStyle.DownwardDiagonal;
                textBox.FillFormat.PatternFormat.ForeColor.Color = Color.Gray; // foreground gray
                textBox.FillFormat.PatternFormat.BackColor.Color = Color.White; // background white

                // Save the presentation
                presentation.Save("PatternFillPresentation.pptx", SaveFormat.Pptx);
            }
        }
    }
}