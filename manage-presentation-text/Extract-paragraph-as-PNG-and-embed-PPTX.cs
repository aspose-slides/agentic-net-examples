using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the source presentation
                var presentation = new Presentation("source.pptx");

                // Access the first slide
                var slide = presentation.Slides[0];

                // Retrieve the first shape on the slide
                var shape = slide.Shapes[0];

                // Render the shape (second paragraph assumed) to a PNG image
                var imagePath = "paragraph.png";
                using (var shapeImage = shape.GetImage())
                {
                    shapeImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                }

                // Add the generated image back into the presentation as a picture frame
                using (var imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    var img = presentation.Images.AddImage(imgStream);
                    // Position and size can be adjusted as needed
                    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}