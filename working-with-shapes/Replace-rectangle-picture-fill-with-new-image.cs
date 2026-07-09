using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string firstImagePath = Path.Combine(dataDir, "image1.jpg");
        string secondImagePath = Path.Combine(dataDir, "image2.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        if (!File.Exists(firstImagePath) || !File.Exists(secondImagePath))
        {
            Console.WriteLine("Input image files not found.");
            return;
        }

        Presentation pres = null;
        try
        {
            pres = new Presentation();
            ISlide slide = pres.Slides[0];

            // Load first image and add to presentation
            IImage firstImg = Images.FromFile(firstImagePath);
            IPPImage firstPpImg = pres.Images.AddImage(firstImg);

            // Add rectangle shape with picture fill
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, firstPpImg.Width, firstPpImg.Height);
            shape.FillFormat.FillType = FillType.Picture;
            IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
            picFill.Picture.Image = firstPpImg;

            // Load second image and replace picture without changing shape size
            IImage secondImg = Images.FromFile(secondImagePath);
            IPPImage secondPpImg = pres.Images.AddImage(secondImg);
            picFill.Picture.Image = secondPpImg;

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}