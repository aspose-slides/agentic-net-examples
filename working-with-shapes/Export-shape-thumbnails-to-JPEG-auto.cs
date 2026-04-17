using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file paths
            string outputPptx = "ShapeThumbnailOutput.pptx";
            string outputJpeg = "ShapeThumbnail.jpg";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle auto shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
            shape.FillFormat.FillType = FillType.NoFill;
            shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

            // Generate shape thumbnail preserving aspect ratio (default bounds)
            IImage shapeImage = shape.GetImage();

            // Save the thumbnail as JPEG
            try
            {
                shapeImage.Save(outputJpeg, Aspose.Slides.ImageFormat.Jpeg);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Save the presentation
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
    }
}