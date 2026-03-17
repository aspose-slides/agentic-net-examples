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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Insert first image from a file stream
            string imagePath1 = "image1.jpg";
            using (FileStream stream1 = new FileStream(imagePath1, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image1 = presentation.Images.AddImage(stream1, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, image1);
            }

            // Insert second image from a byte array
            string imagePath2 = "image2.png";
            byte[] imageData2 = File.ReadAllBytes(imagePath2);
            Aspose.Slides.IPPImage image2 = presentation.Images.AddImage(imageData2);
            slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 350, 0, 300, 200, image2);

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}