using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "PictureFillExample.pptx";
        string imagePath = "sample.jpg";

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

                // Set fill type to picture
                rectangle.FillFormat.FillType = Aspose.Slides.FillType.Picture;

                // Load image and assign to shape fill
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
                    rectangle.FillFormat.PictureFillFormat.Picture.Image = image;
                }

                // Crop picture within the shape (10% from each side)
                rectangle.FillFormat.PictureFillFormat.CropTop = 0.1f;
                rectangle.FillFormat.PictureFillFormat.CropBottom = 0.1f;
                rectangle.FillFormat.PictureFillFormat.CropLeft = 0.1f;
                rectangle.FillFormat.PictureFillFormat.CropRight = 0.1f;

                // Save the presentation
                presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
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