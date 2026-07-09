using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
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
                    // Ensure there is at least one slide and one shape
                    if (presentation.Slides.Count == 0)
                    {
                        Console.WriteLine("Presentation contains no slides.");
                        return;
                    }

                    if (presentation.Slides[0].Shapes.Count == 0)
                    {
                        Console.WriteLine("First slide contains no shapes.");
                        return;
                    }

                    // Get the first shape's line format
                    IShape shape = presentation.Slides[0].Shapes[0];
                    ILineFormat lineFormat = shape.LineFormat;

                    // Original dash style (as defined on the shape)
                    LineDashStyle originalDash = lineFormat.DashStyle;

                    // Effective dash style after theme inheritance
                    ILineFormatEffectiveData effectiveLine = lineFormat.GetEffective();
                    LineDashStyle effectiveDash = effectiveLine.DashStyle;

                    // Output the comparison
                    Console.WriteLine("Original Dash Style : " + originalDash);
                    Console.WriteLine("Effective Dash Style: " + effectiveDash);

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file read errors, external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}