using System;
using System.IO;
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
            Console.WriteLine("Input images not found.");
            return;
        }

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        Aspose.Slides.IImage img1;
        try
        {
            img1 = Aspose.Slides.Images.FromFile(firstImagePath);
        }
        catch (Exception)
        {
            // format not supported
            Console.WriteLine("First image format not supported.");
            return;
        }

        Aspose.Slides.IPPImage ppImg1 = pres.Images.AddImage(img1);
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, ppImg1.Width, ppImg1.Height);
        shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
        shape.FillFormat.PictureFillFormat.Picture.Image = ppImg1;

        Aspose.Slides.IImage img2;
        try
        {
            img2 = Aspose.Slides.Images.FromFile(secondImagePath);
        }
        catch (Exception)
        {
            // format not supported
            Console.WriteLine("Second image format not supported.");
            return;
        }

        Aspose.Slides.IPPImage ppImg2 = pres.Images.AddImage(img2);
        shape.FillFormat.PictureFillFormat.Picture.Image = ppImg2;

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}