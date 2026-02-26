using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output directory
            string outDir = "Output";
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with two paragraphs
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 400f, 200f);
            shape.AddTextFrame("First paragraph");
            Aspose.Slides.Paragraph secondParagraph = new Aspose.Slides.Paragraph();
            secondParagraph.Text = "Second paragraph";
            shape.TextFrame.Paragraphs.Add(secondParagraph);

            // Render the shape (which contains the second paragraph) to an image
            Aspose.Slides.IImage shapeImage = shape.GetImage(
                Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);

            // Save the rendered image as PNG
            string pngPath = Path.Combine(outDir, "Paragraph2.png");
            shapeImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);

            // Add the PNG image back to the slide as a picture frame
            Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(shapeImage);
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                500f, 50f,
                ppImage.Width,
                ppImage.Height,
                ppImage);

            // Save the presentation
            string pptxPath = Path.Combine(outDir, "Result.pptx");
            presentation.Save(pptxPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}