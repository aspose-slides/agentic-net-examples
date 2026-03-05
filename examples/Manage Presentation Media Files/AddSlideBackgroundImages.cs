using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the image file
        var imagePath = Path.Combine("Data", "background.jpg");

        // Create a new presentation
        using (var pres = new Aspose.Slides.Presentation())
        {
            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage img = pres.Images.AddImage(File.ReadAllBytes(imagePath));

            // Apply the image as background to each slide
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                var slide = pres.Slides[i];
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                slide.Background.FillFormat.PictureFillFormat.Picture.Image = img;
            }

            // Save the presentation
            pres.Save("SlideBackgrounds.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}