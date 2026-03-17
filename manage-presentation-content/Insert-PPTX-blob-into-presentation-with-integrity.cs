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

            // Path to the large binary BLOB (e.g., a large image or any binary file)
            string blobPath = "large_blob.bin";

            // Create a dummy large file if it does not exist (10 MB for demonstration)
            if (!File.Exists(blobPath))
            {
                byte[] dummyData = new byte[10 * 1024 * 1024];
                new Random().NextBytes(dummyData);
                File.WriteAllBytes(blobPath, dummyData);
            }

            // Add the binary BLOB to the presentation as an image using KeepLocked behavior
            using (FileStream fileStream = new FileStream(blobPath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(fileStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 400, 300, image);
            }

            // Save the presentation before exiting
            presentation.Save("PresentationWithBlob.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}