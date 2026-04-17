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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide (or any specific slide by index)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define size of 2 centimeters in points (1 cm ≈ 28.3464567 points)
            float sizeInPoints = 2f * 28.3464567f;

            // Add a rectangle shape that will be transformed into a 3D cube
            Aspose.Slides.IAutoShape cubeShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100f, // X position
                100f, // Y position
                sizeInPoints, // Width
                sizeInPoints  // Height
            );

            // Set 3D properties to make it appear as a cube
            cubeShape.ThreeDFormat.Depth = sizeInPoints;               // Depth equal to width/height
            cubeShape.ThreeDFormat.ExtrusionHeight = sizeInPoints;    // Extrusion height equal to size
            cubeShape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;

            // Optional: set a simple fill color for better visibility
            cubeShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            cubeShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

            // Save the presentation
            string outputPath = "CubePresentation.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}