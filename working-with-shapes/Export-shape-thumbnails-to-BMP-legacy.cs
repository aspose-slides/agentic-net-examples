using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file names
            string outputPptx = "ShapeThumbnailExport.pptx";
            string outputBmp = "ShapeThumbnail.bmp";

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape to the slide
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

                // Set shape fill to no fill
                shape.FillFormat.FillType = FillType.NoFill;

                // Set shape line to scribble sketch type
                shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

                // Generate a thumbnail image of the shape with full scale
                IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);

                // Save the shape thumbnail as BMP
                shapeImage.Save(outputBmp, Aspose.Slides.ImageFormat.Bmp);

                // Save the presentation
                pres.Save(outputPptx, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested image format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}