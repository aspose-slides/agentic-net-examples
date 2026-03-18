using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace StrokeThicknessExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 100, 300, 150);

                // Set the line (stroke) thickness to 5 points
                rectangle.LineFormat.Width = 5.0f;

                // Optionally set line color for visibility
                rectangle.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rectangle.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

                // Add a line shape and set its thickness
                Aspose.Slides.IAutoShape line = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 50, 300, 350, 0);
                line.LineFormat.Width = 3.0f;
                line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

                // Save the presentation
                presentation.Save("StrokeThicknessDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}