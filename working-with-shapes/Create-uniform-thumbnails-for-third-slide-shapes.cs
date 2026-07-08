using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string thumbnailsDir = "thumbnails";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(thumbnailsDir))
        {
            Directory.CreateDirectory(thumbnailsDir);
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            if (pres.Slides.Count < 3)
            {
                Console.WriteLine("Presentation does not have a third slide.");
                pres.Dispose();
                return;
            }

            Aspose.Slides.ISlide slide = pres.Slides[2]; // third slide (0‑based index)

            int shapeIndex = 0;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Generate thumbnail with uniform scaling (full size)
                Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
                string shapeImagePath = Path.Combine(thumbnailsDir, $"shape_{shapeIndex}.png");
                shapeImage.Save(shapeImagePath, Aspose.Slides.ImageFormat.Png);
                shapeIndex++;
            }

            // Save the presentation before exiting
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}