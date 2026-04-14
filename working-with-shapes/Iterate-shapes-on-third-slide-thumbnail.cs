using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output directory for thumbnails and saved presentation
        string outputDir = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Check that the third slide exists (index 2)
            if (pres.Slides.Count < 3)
            {
                Console.WriteLine("Presentation does not contain a third slide.");
                pres.Dispose();
                return;
            }

            // Access the third slide
            Aspose.Slides.ISlide slide = pres.Slides[2];

            // Iterate all shapes on the third slide
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];

                // Generate a uniformly sized thumbnail for the shape (scale 1.0f for both axes)
                Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);

                // Save thumbnail as PNG
                string shapeOutputPath = Path.Combine(outputDir, $"shape_{i + 1}.png");
                shapeImage.Save(shapeOutputPath, Aspose.Slides.ImageFormat.Png);
            }

            // Save the (potentially unchanged) presentation before exiting
            string outputPptxPath = Path.Combine(outputDir, "output.pptx");
            pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions as needed
        }
    }
}