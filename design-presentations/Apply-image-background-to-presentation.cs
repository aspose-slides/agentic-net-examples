using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyImageBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the image file to be used as background
                string imagePath = "background.jpg";

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Load the image from file
                    using (FileStream imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        // Add image to the presentation's image collection
                        IPPImage img = pres.Images.AddImage(imgStream);
                        
                        // Apply the image as background to each slide
                        for (int i = 0; i < pres.Slides.Count; i++)
                        {
                            ISlide slide = pres.Slides[i];
                            slide.Background.Type = BackgroundType.OwnBackground;
                            slide.Background.FillFormat.FillType = FillType.Picture;
                            slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                            slide.Background.FillFormat.PictureFillFormat.Picture.Image = img;
                        }
                    }

                    // Save the presentation
                    pres.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}