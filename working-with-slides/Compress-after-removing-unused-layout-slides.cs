using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

class Program
{
    static void Main()
    {
        // Define input and output file names
        string inputFileName = "input.pptx";
        string inputPath = Path.Combine(Environment.CurrentDirectory, inputFileName);

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load presentation with exception handling for unsupported formats
        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            // Format not supported
            return;
        }

        // Delete layout‑specific slides (example: remove the first slide if it exists)
        if (pres.Slides.Count > 0)
        {
            ISlide slideToRemove = pres.Slides[0];
            slideToRemove.Remove();
        }

        // Remove unused layout slides to reduce file size
        Compress.RemoveUnusedLayoutSlides(pres);
        // Optionally remove unused master slides as well
        Compress.RemoveUnusedMasterSlides(pres);

        // Save the modified presentation
        string outputFileName = "output.pptx";
        string outputPath = Path.Combine(Environment.CurrentDirectory, outputFileName);
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}