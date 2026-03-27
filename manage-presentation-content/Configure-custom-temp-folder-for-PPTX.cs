using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define custom temporary folder for PPTX handling
            string tempFolder = Path.Combine(Environment.CurrentDirectory, "CustomTemp");
            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);

            // Configure BlobManagementOptions with custom temp path
            BlobManagementOptions blobOptions = new BlobManagementOptions();
            blobOptions.TempFilesRootPath = tempFolder;
            blobOptions.IsTemporaryFilesAllowed = true;

            // Create LoadOptions using the configured BlobManagementOptions
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.BlobManagementOptions = blobOptions;

            // Create a new presentation with the custom load options
            Presentation pres = new Presentation(loadOptions);

            // (Optional) Add a simple shape to the presentation
            ISlide slide = pres.Slides[0];
            slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);

            // Define output folder and ensure it exists
            string outputFolder = Path.Combine(Environment.CurrentDirectory, "Output");
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Save the presentation to the output folder
            string outPath = Path.Combine(outputFolder, "Result.pptx");
            pres.Save(outPath, SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}