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
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Increase slide size and maximize objects to fill the new size
                presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A4Paper, Aspose.Slides.SlideSizeScaleType.Maximize);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}