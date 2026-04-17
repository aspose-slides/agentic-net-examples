using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace GetEffectiveLineColor
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure input file exists; if not, create a new presentation
            if (!File.Exists(inputPath))
            {
                using (Presentation newPres = new Presentation())
                {
                    newPres.Save(inputPath, SaveFormat.Pptx);
                }
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

                // Set line format to use a scheme color (Accent1)
                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;

                // Apply a custom color to the presentation's master theme Accent1
                IColorFormat accent1Format = pres.MasterTheme.ColorScheme.Accent1;
                accent1Format.Color = Color.Blue;

                // Retrieve the effective line color after applying the custom scheme
                ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();
                Color effectiveColor = effectiveLine.FillFormat.SolidFillColor;

                Console.WriteLine("Effective line color: " + effectiveColor.ToString());

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}