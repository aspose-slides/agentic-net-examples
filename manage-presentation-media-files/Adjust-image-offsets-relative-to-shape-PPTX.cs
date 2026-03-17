using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Load an image from disk
                using (FileStream imgStream = new FileStream("image.jpg", FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage img = pres.Images.AddImage(imgStream);

                    // Add a picture frame at the origin (0,0) with the image's original size
                    Aspose.Slides.IPictureFrame picFrame = slide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        0f,
                        0f,
                        img.Width,
                        img.Height,
                        img);

                    // Define offset values (e.g., 50 points from left, 30 points from top)
                    float offsetX = 50f;
                    float offsetY = 30f;

                    // Apply offsets relative to the shape's bounding‑box edges
                    picFrame.X = picFrame.X + offsetX;
                    picFrame.Y = picFrame.Y + offsetY;
                }

                // Save the modified presentation
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}