using System;
using Aspose.Slides;
using Aspose.Slides.Export;

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

            // Get the first shape on the slide (adjust index as needed)
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Generate a thumbnail image of the shape with default scaling
            Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);

            // Save the shape thumbnail as PNG
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the (potentially modified) presentation
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}