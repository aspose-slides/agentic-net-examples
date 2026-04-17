using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = @"C:\Presentations\sample.pptx";
        // UNC network share folder for thumbnails
        string uncFolder = @"\\Server\Share\Thumbnails";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure the UNC folder exists
        if (!Directory.Exists(uncFolder))
        {
            try
            {
                Directory.CreateDirectory(uncFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create UNC directory: " + ex.Message);
                return;
            }
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Generate and save thumbnails for each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                Aspose.Slides.IImage image = slide.GetImage(1f, 1f);
                string outputFile = Path.Combine(uncFolder, $"Slide_{i + 1}.png");
                image.Save(outputFile, Aspose.Slides.ImageFormat.Png);
                image.Dispose();
            }

            // Save a copy of the presentation to the UNC share before exiting
            string presOutput = Path.Combine(uncFolder, "Copy.pptx");
            presentation.Save(presOutput, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (UnauthorizedAccessException uaEx)
        {
            // Handle access permission errors
            Console.WriteLine("Access denied: " + uaEx.Message);
        }
        catch (NotSupportedException nsEx)
        {
            // Format not supported
            // format not supported
            Console.WriteLine("Format not supported: " + nsEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}