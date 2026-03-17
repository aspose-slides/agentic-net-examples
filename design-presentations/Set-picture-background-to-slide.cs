using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBackgroundExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var presentation = new Presentation();

                // Load image bytes and add to presentation's image collection
                var imagePath = "Tulips.jpg";
                var imageBytes = File.ReadAllBytes(imagePath);
                var picture = presentation.Images.AddImage(imageBytes);

                // Set background to picture
                var slide = presentation.Slides[0];
                slide.Background.Type = BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = FillType.Picture;
                slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                slide.Background.FillFormat.PictureFillFormat.Picture.Image = picture;

                // Save the presentation
                presentation.Save("SlideWithBackground.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}