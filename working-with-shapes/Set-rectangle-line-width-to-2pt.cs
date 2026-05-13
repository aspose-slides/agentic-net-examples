using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output directory and file
                string outputDir = "Output";
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
                string outputPath = Path.Combine(outputDir, "RectangleLineWidth.pptx");

                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

                // Set shape fill to white
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.White;

                // Configure line format
                shape.LineFormat.Style = LineStyle.ThickThin;
                shape.LineFormat.Width = 2.0; // Set line width to 2 points
                shape.LineFormat.DashStyle = LineDashStyle.Dash;
                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Retrieve effective line width
                ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();
                double effectiveWidth = effectiveLine.Width;
                Console.WriteLine("Effective line width: " + effectiveWidth);

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}