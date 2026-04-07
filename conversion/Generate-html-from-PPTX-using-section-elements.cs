using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input PPTX and output HTML
        string inputPath = "input.pptx";
        string outputPath = "output.html";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("The input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation from the specified file
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Export the presentation to HTML.
                // The default HTML exporter uses <section> elements for each slide.
                presentation.Save(outputPath, SaveFormat.Html);
            }
        }
        catch (NotSupportedException)
        {
            // The file format is not supported by Aspose.Slides
            // format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., issues with external resources)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}