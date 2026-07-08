using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string outputPath = "RoundedRectanglePresentation.pptx";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Ensure there are at least three slides
                while (pres.Slides.Count < 3)
                {
                    // Add empty slides based on the layout of the first slide
                    pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                }

                // Get the third slide (index 2)
                ISlide slide = pres.Slides[2];

                // Add a rounded rectangle auto shape
                IAutoShape shape = slide.Shapes.AddAutoShape(
                    ShapeType.RoundCornerRectangle,
                    100f,   // X position
                    100f,   // Y position
                    300f,   // Width
                    150f    // Height
                );

                // Set corner radius to 10 points if the adjustment type matches
                if (shape.Adjustments.Count > 0 && shape.Adjustments[0].Type == ShapeAdjustmentType.Radius)
                {
                    // RawValue is used for radius adjustments (value in points)
                    shape.Adjustments[0].RawValue = 10;
                }

                // Apply solid fill using a scheme color
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;

                // Ensure output directory exists
                string outDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}