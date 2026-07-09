using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchAddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: BatchAddLines <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file does not exist: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through all slides
                foreach (ISlide slide in pres.Slides)
                {
                    // Add ten plain line shapes with incremental Y offset
                    for (int i = 0; i < 10; i++)
                    {
                        float x = 50f;
                        float y = 50f + i * 20f; // Incremental Y offset
                        float width = 300f;
                        float height = 0f; // Height zero for a horizontal line

                        // Add line shape
                        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, x, y, width, height);
                        // Optional: set line width
                        line.LineFormat.Width = 2f;
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine($"Presentation saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported comment
                Console.WriteLine($"Error processing presentation: {ex.Message}");
            }
        }
    }
}