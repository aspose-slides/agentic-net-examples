using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Export each slide to a JPEG image using baseline DCT (default for JPEG)
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];

                    // Generate a full‑scale image of the slide
                    IImage image = slide.GetImage(1f, 1f);

                    // Define output file name
                    string outputFile = $"slide_{i + 1}.jpg";

                    // Save the image as JPEG with quality 80 (baseline DCT encoder)
                    image.Save(outputFile, Aspose.Slides.ImageFormat.Jpeg, 80);

                    // Release image resources
                    image.Dispose();
                }

                // Save the presentation (no modifications) to satisfy lifecycle rule
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}