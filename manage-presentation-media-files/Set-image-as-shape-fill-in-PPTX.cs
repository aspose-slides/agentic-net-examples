using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to the slide
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50f, 50f, 400f, 300f);

                // Load an image from file and add it to the presentation's image collection
                string imagePath = "sample.jpg";
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    IPPImage img = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);

                    // Set the shape's fill type to picture and assign the image
                    shape.FillFormat.FillType = FillType.Picture;
                    shape.FillFormat.PictureFillFormat.Picture.Image = img;
                }

                // Save the presentation to disk
                presentation.Save("ImageFillPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}