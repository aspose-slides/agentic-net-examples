using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string imagePath = Path.Combine(dataDir, "image.jpg");
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        Presentation pres = new Presentation();
        IImage img = Aspose.Slides.Images.FromFile(imagePath);
        IPPImage pptImg = pres.Images.AddImage(img);
        IPictureFrame pf = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pptImg.Width, pptImg.Height, pptImg);
        SlideUtil.AlignShapes(ShapesAlignmentType.AlignCenter, true, pres.Slides[0]);

        string outPath = Path.Combine(dataDir, "output.pptx");
        try
        {
            pres.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}