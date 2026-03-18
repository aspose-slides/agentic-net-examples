using System;
using Aspose.Slides.Export;

namespace ShapeThumbnailExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input and output file paths
                string inputPptx = "input.pptx";
                string outputPptx = "output.pptx";
                string outputPng = "shape_thumbnail.png";

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPptx);

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Access the first shape on the slide
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Calculate scaling factors to obtain a 200x200 pixel thumbnail
                float scaleX = 200f / shape.Width;
                float scaleY = 200f / shape.Height;

                // Generate the shape thumbnail and save as PNG
                using (Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY))
                {
                    shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
                }

                // Save the (potentially modified) presentation
                pres.Save(outputPptx, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}