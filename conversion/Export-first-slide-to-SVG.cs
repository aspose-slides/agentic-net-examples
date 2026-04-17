using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string svgOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "slide1.svg");
        string presentationSavePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Export the first slide as SVG using the slide's WriteAsSvg method
            using (FileStream svgStream = File.Create(svgOutputPath))
            {
                presentation.Slides[0].WriteAsSvg(svgStream);
            }

            // Save the presentation before exiting
            presentation.Save(presentationSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for this operation.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}