using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the local image file
        string imagePath = "sample.jpg";
        // Path where the output presentation will be saved
        string outputPath = "PresentationWithImage.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Open the image file as a stream
        FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

        // Add the image to the presentation's image collection (keep the stream locked)
        Aspose.Slides.IPPImage img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

        // Insert the image onto the first slide as a picture frame
        pres.Slides[0].Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle, // Shape type
            0,    // X position
            0,    // Y position
            300,  // Width
            200,  // Height
            img   // Image to display
        );

        // Save the presentation to disk in PPTX format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        fs.Close();
        pres.Dispose();
    }
}