using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationMediaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the image file that will be used as slide background
            string imagePath = "background.jpg";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Add the image to the presentation's image collection
                IPPImage backgroundImage = pres.Images.AddImage(File.ReadAllBytes(imagePath));

                // Configure the first slide's background to use the added image
                pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
                pres.Slides[0].Background.FillFormat.FillType = FillType.Picture;
                pres.Slides[0].Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                pres.Slides[0].Background.FillFormat.PictureFillFormat.Picture.Image = backgroundImage;

                // Save the presentation to a PPTX file
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}