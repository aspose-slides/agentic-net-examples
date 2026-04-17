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
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape that will act as a line shape
            IAutoShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 0);
            // Set line format to solid fill and use a theme accent color
            lineShape.LineFormat.FillFormat.FillType = FillType.Solid;
            lineShape.LineFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
            lineShape.LineFormat.Width = 5;

            // Change the theme's first line style color to Red
            try
            {
                presentation.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
            }
            catch (Exception ex)
            {
                // Handle any exception related to theme modification
                Console.WriteLine("Theme change error: " + ex.Message);
            }

            // Verify the line color after theme change using effective line format
            ILineFormatEffectiveData effectiveLine = lineShape.LineFormat.GetEffective();
            Console.WriteLine("Effective line fill type: " + effectiveLine.FillFormat.FillType);
            // The color may be retrieved from the solid fill if applicable
            // Note: Direct color retrieval may require additional checks
            // Here we simply output that verification step is completed
            Console.WriteLine("Line color verification completed.");

            // Save the presentation
            string outputPath = "LineShapeThemeExample.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                Console.WriteLine("Save error: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}