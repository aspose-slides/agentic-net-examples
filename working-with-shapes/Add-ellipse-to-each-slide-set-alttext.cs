using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <input.pptx> <output.pptx>");
            return;
        }

        var inputPath = args[0];
        var outputPath = args[1];

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var id = 1;
                // Iterate through each slide and add an ellipse with sequential AltText
                foreach (var slide in presentation.Slides)
                {
                    var ellipse = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Ellipse,
                        100, 100, 200, 100);
                    ellipse.AlternativeText = id.ToString();
                    id++;
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors, Aspose-specific errors)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}