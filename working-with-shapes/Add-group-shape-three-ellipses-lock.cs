using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace GroupShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            var presentation = new Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a group shape to the slide
            var groupShape = slide.Shapes.AddGroupShape();

            // Add three ellipses to the group shape with different fill colors
            var ellipse1 = groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
            ellipse1.FillFormat.FillType = FillType.Solid;
            ellipse1.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 200, 200); // Light red

            var ellipse2 = groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);
            ellipse2.FillFormat.FillType = FillType.Solid;
            ellipse2.FillFormat.SolidFillColor.Color = Color.FromArgb(200, 255, 200); // Light green

            var ellipse3 = groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 350, 50, 100, 100);
            ellipse3.FillFormat.FillType = FillType.Solid;
            ellipse3.FillFormat.SolidFillColor.Color = Color.FromArgb(200, 200, 255); // Light blue

            // Lock the group shape to prevent moving/resizing (affects contained shapes)
            groupShape.GroupShapeLock.PositionLocked = true;
            groupShape.GroupShapeLock.SizeLocked = true;

            // Define output path
            var outputDir = "Output";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            var outputPath = Path.Combine(outputDir, "GroupShapeEllipses.pptx");

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}