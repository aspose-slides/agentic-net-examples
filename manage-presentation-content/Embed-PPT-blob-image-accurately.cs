using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input image and output presentation
        string inputImagePath = "image.jpg";
        string outputPptxPath = "output.pptx";

        // Verify that the input image file exists
        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine("Input image file does not exist.");
            return;
        }

        // Ensure the output directory exists
        string outputDirectory = Path.GetDirectoryName(outputPptxPath);
        if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Open a file stream for the image and add it to the presentation
        FileStream fs = new FileStream(inputImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        Aspose.Slides.IPPImage img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
        fs.Close();

        // Add a picture frame containing the image to the first slide
        pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);

        // Save the presentation
        pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}