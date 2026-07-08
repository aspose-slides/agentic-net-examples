using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file paths
            string outputPptx = "ShapeThumbnailDemo.pptx";
            string outputPng = "ShapeThumbnail.png";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape to the slide
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);

            // Set shape fill to no fill
            shape.FillFormat.FillType = FillType.NoFill;

            // Set line sketch type to Scribble
            shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

            // Generate a thumbnail image of the shape with precise bounds
            IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);

            // Save the shape thumbnail as PNG
            shapeImage.Save(outputPng, ImageFormat.Png);

            // Save the presentation
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
    }
}