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
            using (Presentation pres = new Presentation())
            {
                // Path to the background image file
                string imagePath = "background.jpg";

                // Load image bytes from file
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // Add image to the presentation's image collection
                IPPImage img = pres.Images.AddImage(imageBytes);

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Set the slide background to use the image
                slide.Background.Type = BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = FillType.Picture;
                slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                slide.Background.FillFormat.PictureFillFormat.Picture.Image = img;

                // Save the presentation
                pres.Save("SlideBackground.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}