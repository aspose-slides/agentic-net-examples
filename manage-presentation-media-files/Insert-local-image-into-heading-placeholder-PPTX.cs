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
            // Paths to the input presentation, the image to insert, and the output file
            string presentationPath = "input.pptx";
            string imagePath = "logo.png";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Load the image file into a stream and add it to the presentation's image collection
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                    // Insert the image into each slide's heading placeholder (here added as a picture frame)
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Add a picture frame at position (10,10) with size 200x100
                        slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 200, 100, image);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}