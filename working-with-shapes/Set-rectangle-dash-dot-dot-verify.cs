using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            IShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);

            // Set line dash style to DashDotDot (using LargeDashDotDot as closest match)
            rect.LineFormat.DashStyle = LineDashStyle.LargeDashDotDot;

            // Retrieve effective line format data
            ILineFormatEffectiveData effectiveLine = rect.LineFormat.GetEffective();

            // Verify the dash style
            Console.WriteLine("Effective Dash Style: " + effectiveLine.DashStyle);

            // Save the presentation
            string outputPath = "RectangleDashDotDot.pptx";
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}