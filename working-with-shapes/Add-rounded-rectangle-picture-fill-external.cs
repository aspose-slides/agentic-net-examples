using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imagePath = Path.Combine(dataDir, "image.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file does not exist: " + imagePath);
                return;
            }

            try
            {
                var pres = new Aspose.Slides.Presentation();

                var shape = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
                shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

                var img = Aspose.Slides.Images.FromFile(imagePath);
                var ppImg = pres.Images.AddImage(img);

                shape.FillFormat.PictureFillFormat.Picture.Image = ppImg;
                shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}