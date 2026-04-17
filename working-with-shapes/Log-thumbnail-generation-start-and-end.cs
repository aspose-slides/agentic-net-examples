using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output folder for thumbnails
        string outputFolder = "Thumbnails";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Scale factors for thumbnails
            int scaleX = 1;
            int scaleY = scaleX;

            // File name format for saved images
            string fileNameFormat = Path.Combine(outputFolder, "Slide_{0}.jpg");

            // Start performance logging
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Thumbnail generation started at " + DateTime.Now);

            // Generate thumbnails for each slide
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    string imageFileName = string.Format(fileNameFormat, slide.SlideNumber);
                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // End performance logging
            stopwatch.Stop();
            Console.WriteLine("Thumbnail generation ended at " + DateTime.Now);
            Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);

            // Save presentation before exit (no modifications made)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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