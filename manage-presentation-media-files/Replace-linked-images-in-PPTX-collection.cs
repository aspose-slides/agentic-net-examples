using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load the target presentation
            string inputPath = "input.pptx";
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Load new image data to replace existing images in the collection
            byte[] newImageData = File.ReadAllBytes("newImage.png");
            int imageCount = pres.Images.Count;
            for (int i = 0; i < imageCount; i++)
            {
                Aspose.Slides.IPPImage img = pres.Images[i];
                img.ReplaceImage(newImageData);
            }

            // Replace images used in picture shapes with an image from another presentation
            for (int s = 0; s < pres.Slides.Count; s++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[s];
                for (int sh = 0; sh < slide.Shapes.Count; sh++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[sh];
                    Aspose.Slides.ISlidesPicture picture = shape as Aspose.Slides.ISlidesPicture;
                    if (picture != null)
                    {
                        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("source.pptx");
                        Aspose.Slides.IPPImage sourceImg = sourcePres.Images[0];
                        picture.Image = sourceImg;
                        sourcePres.Dispose();
                    }
                }
            }

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}