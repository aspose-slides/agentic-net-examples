using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input presentation file
        var inputPath = "sample.pptx";
        // Path to the output presentation file after processing
        var outputPath = "output.pptx";

        try
        {
            // LoadOptions with automatic format detection (recommended for most scenarios)
            var loadOptions = new Aspose.Slides.LoadOptions(Aspose.Slides.LoadFormat.Auto);

            // Open the presentation using the specified load options
            using (var presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Retrieve and display the detected source format
                var sourceFormat = presentation.SourceFormat;
                Console.WriteLine($"Loaded format: {sourceFormat}");

                // Save the presentation to ensure resources are released and to demonstrate a safe exit
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to {outputPath}");
            }
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine($"Unsupported PPT format: {ex.Message}");
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            Console.WriteLine($"Unsupported PPTX format: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}