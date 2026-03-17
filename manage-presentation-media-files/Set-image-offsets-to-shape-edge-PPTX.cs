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
            var presentationPath = "input.pptx";
            var imagePath = "image.jpg";
            var outputPath = "output.pptx";

            using (var presentation = new Presentation(presentationPath))
            {
                var slide = presentation.Slides[0];

                // Add image to the presentation
                using (var imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    var img = presentation.Images.AddImage(imgStream, LoadingStreamBehavior.KeepLocked);

                    // Insert picture frame
                    var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

                    // Set offsets relative to the shape's bounding box (e.g., 10 points from left/top edges)
                    pictureFrame.X = pictureFrame.X + 10;
                    pictureFrame.Y = pictureFrame.Y + 10;
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