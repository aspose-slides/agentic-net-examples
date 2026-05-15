using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string watermarkPath = "watermark.png";
        string outputPath = "output.pptx";

        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found.");
            return;
        }
        if (!File.Exists(watermarkPath))
        {
            Console.WriteLine("Watermark image file not found.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath))
            {
                // Load watermark image bytes and add to the presentation
                byte[] watermarkBytes = File.ReadAllBytes(watermarkPath);
                Aspose.Slides.IPPImage watermarkImg = pres.Images.AddImage(watermarkBytes);

                // Apply watermark as background to each slide
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                    slide.Background.FillFormat.PictureFillFormat.Picture.Image = watermarkImg;

                    // Set opacity to 30%
                    slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(30f);
                }

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web services)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}