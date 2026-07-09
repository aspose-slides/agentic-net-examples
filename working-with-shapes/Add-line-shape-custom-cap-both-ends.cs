using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomCapLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CustomCapLine.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line shape to the slide
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

            // Set line width
            line.LineFormat.Width = 5;

            // Set custom cap style for both ends
            line.LineFormat.CapStyle = LineCapStyle.Square;

            // Set line color
            line.LineFormat.FillFormat.FillType = FillType.Solid;
            line.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}