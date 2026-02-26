using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Access the first shape on the slide (ensure at least one shape exists)
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Generate a thumbnail image for the shape
            using (Aspose.Slides.IImage shapeImage = shape.GetImage())
            {
                // Save the shape thumbnail as a PNG file
                shapeImage.Save("shape_thumbnail.png", ImageFormat.Png);
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}