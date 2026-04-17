using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path (first argument or default)
        var inputPath = args.Length > 0 ? args[0] : "input.pptx";

        // Check if the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the presentation
            using (var presentation = new Presentation(inputPath))
            {
                // Iterate through each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var count3D = 0;

                    // Count shapes that have a 3D format
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape.ThreeDFormat != null)
                            count3D++;
                    }

                    Console.WriteLine($"Slide {i + 1}: {count3D} 3D object(s)");
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        // Handle unsupported format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}