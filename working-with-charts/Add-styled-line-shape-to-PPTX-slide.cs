using System;
using System.Drawing;
using Aspose.Slides.Export;

namespace CustomLineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "CustomLinePresentation.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line shape with specified position and size
            Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Line, 100, 100, 400, 0);

            // Set line style parameters
            lineShape.LineFormat.Width = 5;
            lineShape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
            lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}