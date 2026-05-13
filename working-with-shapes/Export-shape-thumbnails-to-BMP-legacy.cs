using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExport
{
    class Program
    {
        static void Main()
        {
            // Output file paths
            string outputPptx = "ShapeThumbnailDemo.pptx";
            string outputBmp = "ShapeThumbnail.bmp";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape to the slide
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
            shape.FillFormat.FillType = FillType.NoFill;
            shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

            // Generate a thumbnail image of the shape with scaling factors
            float scaleX = 1f;
            float scaleY = 1f;
            IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);

            // Save the shape thumbnail as BMP
            shapeImage.Save(outputBmp, Aspose.Slides.ImageFormat.Bmp);

            // Save the presentation
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
    }
}