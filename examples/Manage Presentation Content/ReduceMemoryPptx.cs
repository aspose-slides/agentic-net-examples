using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BlobMemoryOptimization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, large image, and output presentation
            string inputPresentationPath = "input.pptx";
            string largeImagePath = "large_image.jpg";
            string outputPresentationPath = "output.pptx";

            // Configure Blob management options to reduce memory consumption
            Aspose.Slides.BlobManagementOptions blobOptions = new Aspose.Slides.BlobManagementOptions();
            blobOptions.IsTemporaryFilesAllowed = true; // Enable temporary files for BLOBs
            blobOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked; // Keep source locked for the lifetime of the presentation
            // Optional: limit memory usage for BLOBs (e.g., 10 MB)
            blobOptions.MaxBlobsBytesInMemory = 10 * 1024 * 1024;

            // Load the presentation with the specified Blob management options
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.BlobManagementOptions = blobOptions;

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentationPath, loadOptions))
            {
                // Add a large image using a stream with KeepLocked behavior to avoid loading the whole image into memory
                using (FileStream imageStream = new FileStream(largeImagePath, FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                    // Insert the image onto the first slide
                    presentation.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, image);
                }

                // Save the modified presentation in PPTX format
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}