using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetBackgroundImage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load or create a presentation
                using (Presentation pres = new Presentation())
                {
                    // Load image data from file
                    byte[] imageData = File.ReadAllBytes("background.jpg");
                    // Add image to the presentation's image collection
                    IPPImage backgroundImage = pres.Images.AddImage(imageData);

                    // Apply the image as background to each slide
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        slide.Background.Type = BackgroundType.OwnBackground;
                        slide.Background.FillFormat.FillType = FillType.Picture;
                        slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                        slide.Background.FillFormat.PictureFillFormat.Picture.Image = backgroundImage;
                    }

                    // Save the presentation
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}