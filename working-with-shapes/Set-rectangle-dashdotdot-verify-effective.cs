using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file path
            string outputDir = "Output";
            string outputPath = Path.Combine(outputDir, "DashStyleDemo.pptx");

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape rect = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);

            // Set the line dash style to dash‑dot‑dot (LargeDashDotDot)
            rect.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDashDotDot;

            // Get effective line format data
            Aspose.Slides.ILineFormatEffectiveData effectiveLine = rect.LineFormat.GetEffective();

            // Verify the effective dash style
            Console.WriteLine("Effective DashStyle: " + effectiveLine.DashStyle);

            // Save the presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}