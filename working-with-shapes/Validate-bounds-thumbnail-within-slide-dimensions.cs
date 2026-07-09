using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Generate a thumbnail with full scale (1:1)
                Aspose.Slides.IImage thumbnail = slide.GetImage(1f, 1f);

                // Retrieve slide dimensions
                int slideWidth = (int)presentation.SlideSize.Size.Width;
                int slideHeight = (int)presentation.SlideSize.Size.Height;

                // Validate that thumbnail does not exceed slide dimensions
                if (thumbnail.Width > slideWidth || thumbnail.Height > slideHeight)
                {
                    Console.WriteLine($"Thumbnail for slide {slide.SlideNumber} exceeds slide dimensions.");
                }
                else
                {
                    Console.WriteLine($"Thumbnail for slide {slide.SlideNumber} is within slide dimensions.");
                }

                // Save the thumbnail as JPEG
                string thumbPath = $"slide_{slide.SlideNumber}_thumb.jpg";
                thumbnail.Save(thumbPath, Aspose.Slides.ImageFormat.Jpeg);
                thumbnail.Dispose();
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
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