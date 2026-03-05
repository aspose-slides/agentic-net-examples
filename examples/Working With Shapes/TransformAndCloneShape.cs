using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TransformAndCloneShape
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation (lifecycle rule)
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            Aspose.Slides.ISlide srcSlide = pres.Slides[0];

            // Add a rectangle shape to demonstrate transformations
            Aspose.Slides.IAutoShape srcShape = srcSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50f,   // X position
                50f,   // Y position
                100f,  // Width
                50f    // Height
            );

            // Move the shape
            srcShape.X = 150f;
            srcShape.Y = 150f;

            // Rotate the shape (use Rotation property, not RotationAngle)
            srcShape.Rotation = 45f; // degrees clockwise

            // Scale the shape (increase size by 1.5 times)
            srcShape.Width = srcShape.Width * 1.5f;
            srcShape.Height = srcShape.Height * 1.5f;

            // Clone the transformed shape onto a new blank slide (clone-shapes rule)
            Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(
                Aspose.Slides.SlideLayoutType.Blank
            );
            Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);
            Aspose.Slides.IShapeCollection destShapes = destSlide.Shapes;
            // AddClone retains original size; specify new position if needed
            destShapes.AddClone(srcShape, 200f, 200f);

            // Save the modified presentation (lifecycle rule)
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}