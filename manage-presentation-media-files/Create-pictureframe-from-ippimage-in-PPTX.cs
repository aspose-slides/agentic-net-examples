using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Load image from file and add it to the presentation
                using (FileStream imageStream = new FileStream("example.jpg", FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                    // Add a picture frame to the first slide using the added image
                    Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        50f, 50f, 400f, 300f,
                        image);
                }

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}