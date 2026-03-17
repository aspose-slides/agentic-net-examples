using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Configure BLOB management options to reduce memory usage
            Aspose.Slides.BlobManagementOptions blobOptions = new Aspose.Slides.BlobManagementOptions();
            blobOptions.IsTemporaryFilesAllowed = true;
            blobOptions.MaxBlobsBytesInMemory = 10 * 1024 * 1024; // 10 MB limit

            // Set load options with the BLOB settings
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.BlobManagementOptions = blobOptions;

            // Create a new presentation using the load options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions);

            // Add a simple rectangle shape to the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Create PPTX save options via the factory (non‑static call)
            Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
            Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

            // Save the presentation with the specified options
            presentation.Save("BlobOptimizedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

            // Release resources explicitly
            presentation.Dispose();
        }
        catch (System.IO.IOException ioEx)
        {
            Console.WriteLine("IO error: " + ioEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}