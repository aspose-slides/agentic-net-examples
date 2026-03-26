using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation with error handling for read exceptions
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Aspose.Slides.PptxReadException ex)
        {
            Console.WriteLine("PptxReadException: " + ex.Message);
            return;
        }
        catch (Aspose.Slides.PptReadException ex)
        {
            Console.WriteLine("PptReadException: " + ex.Message);
            return;
        }

        // Standardize slide size across all slides (A4 paper with EnsureFit scaling)
        presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A4Paper, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}