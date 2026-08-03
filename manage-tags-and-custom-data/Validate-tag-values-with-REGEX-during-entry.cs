// -----------------------------------------------------------------------------
// Example: Validate tag values with REGEX during entry using C#
//
// Description:
// Demonstrates how to validate shape alternative text tags in a PowerPoint
// presentation using a regular expression with Aspose.Slides for .NET. The
// example loads a PPTX file, checks each shape's AlternativeText against a
// pattern (three uppercase letters, a dash, and four digits), replaces any
// non‑conforming tags with the placeholder "INVALID", and saves the updated
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Tag, Regex, AlternativeText, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure shape tags follow a predefined naming convention before publishing.
// - Automate validation of metadata embedded in PowerPoint files.
// - Build .NET tools that clean or correct tag values in presentations.
// - Integrate tag validation into larger PPTX workflow pipelines.
// -----------------------------------------------------------------------------
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
