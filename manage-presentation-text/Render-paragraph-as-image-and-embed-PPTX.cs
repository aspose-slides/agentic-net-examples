using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Output directory
                string outDir = "Output";
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape with a paragraph
                IAutoShape autoShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                autoShape.TextFrame.Text = "This paragraph will be rendered as an image and embedded back into the presentation.";

                // Render the slide (including the paragraph) to an image
                IImage slideImage = slide.GetImage(1f, 1f);

                // Add the rendered image to the presentation's image collection
                IPPImage embeddedImage = presentation.Images.AddImage(slideImage);

                // Insert the image as a picture frame on the same slide (or another slide)
                slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 100, 200, slideImage.Width, slideImage.Height, embeddedImage);

                // Save the presentation
                presentation.Save(Path.Combine(outDir, "RenderedParagraph.pptx"), SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}