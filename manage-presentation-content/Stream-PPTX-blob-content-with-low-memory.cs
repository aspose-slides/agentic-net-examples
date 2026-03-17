using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesBlobExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";
                var imagePath = "large_image.jpg";

                // Configure load options to use temporary files for BLOB handling
                var loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;

                // Open the presentation from a file stream with the specified load options
                using (var fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                using (var presentation = new Aspose.Slides.Presentation(fileStream, loadOptions))
                {
                    // Add a large image as a BLOB using a stream to keep memory usage low
                    using (var imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        var img = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                        presentation.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}