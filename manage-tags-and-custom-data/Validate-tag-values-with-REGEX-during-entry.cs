using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Define regex pattern for tag validation (e.g., three letters followed by a dash and four digits)
            var tagPattern = new Regex(@"^[A-Z]{3}-\d{4}$");

            // Iterate through all slides and shapes to validate alternative text tags
            foreach (var slide in presentation.Slides)
            {
                foreach (var shape in slide.Shapes)
                {
                    if (!string.IsNullOrEmpty(shape.AlternativeText) && !tagPattern.IsMatch(shape.AlternativeText))
                    {
                        // Mark invalid tags (example: set to "INVALID")
                        shape.AlternativeText = "INVALID";
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access issues)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}