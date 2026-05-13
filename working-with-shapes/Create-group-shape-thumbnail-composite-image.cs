using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupShapeThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add an empty group shape to the slide
                IGroupShape groupShape = slide.Shapes.AddGroupShape();

                // Add some shapes inside the group
                groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100f, 100f, 200f, 100f);
                groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 150f, 150f, 200f, 100f);
                groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 200f, 200f, 150f, 150f);

                // Generate thumbnail image of the group shape
                IImage groupImage = groupShape.GetImage();

                // Save the thumbnail as PNG
                string outputPngPath = "group_thumbnail.png";
                groupImage.Save(outputPngPath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation
                string outputPptxPath = "group_shape_output.pptx";
                pres.Save(outputPptxPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}