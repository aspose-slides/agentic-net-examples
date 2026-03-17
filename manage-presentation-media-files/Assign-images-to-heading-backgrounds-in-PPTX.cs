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
                // Path to the heading image file
                string imagePath = "heading.jpg";

                // Load image bytes and add to the presentation's image collection
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                Aspose.Slides.IPPImage headingImage = pres.Images.AddImage(imageBytes);

                // Apply the image as background to each slide
                for (int index = 0; index < pres.Slides.Count; index++)
                {
                    ISlide slide = pres.Slides[index];
                    slide.Background.Type = BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = FillType.Picture;
                    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                    slide.Background.FillFormat.PictureFillFormat.Picture.Image = headingImage;
                }

                // Save the presentation before exiting
                pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}