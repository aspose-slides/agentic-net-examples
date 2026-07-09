using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputFileName = "EllipseLongDash.pptx";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an ellipse shape to the slide
            IShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 150);

            // Set the line dash style to LargeDash (long dash)
            ellipse.LineFormat.DashStyle = LineDashStyle.LargeDash;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}