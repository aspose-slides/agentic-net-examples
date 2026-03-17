using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            var imagePath = "background.jpg";
            var outputPath = "output.pptx";

            using (var pres = new Aspose.Slides.Presentation(presentationPath))
            {
                var imageBytes = File.ReadAllBytes(imagePath);
                Aspose.Slides.IPPImage img = pres.Images.AddImage(imageBytes);

                for (var i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                    slide.Background.FillFormat.PictureFillFormat.Picture.Image = img;
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}