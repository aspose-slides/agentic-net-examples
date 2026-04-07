using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputSwfPath = "output.swf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Determine maximum slide resolution
            int maxWidth = 0;
            int maxHeight = 0;
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Get full‑scale image of the slide
                using (Aspose.Slides.IImage img = slide.GetImage(1f, 1f))
                {
                    if (img.Width > maxWidth) maxWidth = img.Width;
                    if (img.Height > maxHeight) maxHeight = img.Height;
                }
            }

            // Adjust JPEG quality based on resolution (simple heuristic)
            int jpegQuality;
            if (maxWidth * maxHeight > 3000000) // high resolution
                jpegQuality = 90;
            else if (maxWidth * maxHeight > 1500000) // medium resolution
                jpegQuality = 80;
            else // low resolution
                jpegQuality = 70;

            // Configure SWF options with dynamic JPEG quality
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.JpegQuality = jpegQuality;

            // Save presentation as SWF using the configured options
            presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Save the presentation before exiting (as required)
            string tempSavePath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", "temp_saved.pptx");
            presentation.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);

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