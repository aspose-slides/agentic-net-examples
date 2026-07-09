using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = @"C:\Presentations\sample.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // UNC directory where thumbnails will be saved
        string uncOutputDir = @"\\Server\Share\Thumbnails";
        try
        {
            if (!Directory.Exists(uncOutputDir))
            {
                Directory.CreateDirectory(uncOutputDir);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied to the UNC path.");
            return;
        }

        // Load the presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported.");
            return;
        }

        // Generate and save thumbnails for each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            ISlide slide = presentation.Slides[i];
            IImage image = slide.GetImage(1f, 1f);
            string outputFile = Path.Combine(uncOutputDir, $"Slide_{i + 1}.png");
            try
            {
                image.Save(outputFile, Aspose.Slides.ImageFormat.Png);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Access denied when saving {outputFile}");
            }
        }

        // Save a copy of the presentation to the UNC share before exiting
        string presentationCopyPath = Path.Combine(uncOutputDir, "Copy.pptx");
        try
        {
            presentation.Save(presentationCopyPath, SaveFormat.Pptx);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied when saving the presentation copy.");
        }

        // Release resources
        presentation.Dispose();
    }
}