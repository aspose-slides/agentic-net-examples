using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RotateShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string outputPath = "RotatedShape_out.pptx";

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100,   // X position
                100,   // Y position
                200,   // Width
                100    // Height
            );

            // Rotate the shape by 45 degrees clockwise
            shape.Rotation = 45f;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}