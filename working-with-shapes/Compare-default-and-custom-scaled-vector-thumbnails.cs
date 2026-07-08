using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Generate default thumbnail (20% of real size)
            Aspose.Slides.IImage defaultImage = slide.GetImage();
            string defaultImagePath = Path.Combine(Path.GetDirectoryName(inputPath), "default_thumbnail.jpg");
            defaultImage.Save(defaultImagePath, Aspose.Slides.ImageFormat.Jpeg);

            // Generate custom scaled thumbnail
            float scaleX = 2.0f; // Example scaling factor for width
            float scaleY = 2.0f; // Example scaling factor for height
            Aspose.Slides.IImage scaledImage = slide.GetImage(scaleX, scaleY);
            string scaledImagePath = Path.Combine(Path.GetDirectoryName(inputPath), "scaled_thumbnail.jpg");
            scaledImage.Save(scaledImagePath, Aspose.Slides.ImageFormat.Jpeg);

            // Save the presentation before exiting (no modifications made)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}