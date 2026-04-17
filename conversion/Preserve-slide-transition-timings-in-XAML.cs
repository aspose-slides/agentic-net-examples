using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file '{inputPath}' does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (var presentation = new Presentation(inputPath))
            {
                // Export to XAML while preserving transition timings and hidden slides
                var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
                presentation.Save(xamlOptions);
            }
        }
        // Handle format not supported scenarios
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The requested format is not supported.");
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}