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
                // Create a new presentation
                Presentation pres = new Presentation();

                // Load background image bytes
                string imagePath = "background.jpg";
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // Add image to the presentation's image collection
                IPPImage img = pres.Images.AddImage(imageBytes);

                // Set the background image for each slide
                foreach (ISlide slide in pres.Slides)
                {
                    slide.Background.Type = BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = FillType.Picture;
                    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                    slide.Background.FillFormat.PictureFillFormat.Picture.Image = img;
                }

                // Save the presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}