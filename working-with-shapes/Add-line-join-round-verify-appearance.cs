using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line shape to the slide
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 300, 0);

            // Set line width
            line.LineFormat.Width = 5;

            // Set line color
            line.LineFormat.FillFormat.FillType = FillType.Solid;
            line.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Set line join style to Round
            line.LineFormat.JoinStyle = LineJoinStyle.Round;

            // Save the presentation
            string outputPath = "LineJoinStyleRound.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}