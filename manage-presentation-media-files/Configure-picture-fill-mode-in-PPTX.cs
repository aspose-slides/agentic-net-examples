using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load image from file
                FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                imageStream.Dispose();

                // Add picture frame to the slide
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 200, image);

                // Set picture fill mode to Tile
                pictureFrame.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}