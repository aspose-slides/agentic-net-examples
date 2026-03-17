using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConfigurePptxTempFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define custom temporary folder for BLOB handling
            string tempFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomTemp");
            if (!Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }

            // Define output presentation path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ResultPresentation.pptx");

            // Prepare load options with custom BlobManagement settings
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            Aspose.Slides.BlobManagementOptions blobOptions = new Aspose.Slides.BlobManagementOptions();
            blobOptions.IsTemporaryFilesAllowed = true;               // Enable temporary files
            blobOptions.TempFilesRootPath = tempFolderPath;           // Set custom root path
            loadOptions.BlobManagementOptions = blobOptions;

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Create a new presentation using the configured load options
                presentation = new Aspose.Slides.Presentation(loadOptions);

                // (Optional) Add a simple slide to demonstrate functionality
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

                // Save the presentation in PPTX format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}