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
            string outputPng = "paragraph.png";
            string outputPptx = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPptx);

            // Access the first slide (adjust index as needed)
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Access the first shape on the slide and cast to AutoShape (adjust index as needed)
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes[0];

            // Retrieve the first paragraph from the shape's text frame
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

            // Export the shape (which contains the paragraph) as a PNG image
            Aspose.Slides.IImage shapeImage = autoShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 2f, 2f);
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the (potentially modified) presentation
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}