using System;
using System.IO;
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
            Console.WriteLine("Input file not found.");
            return;
        }

        try
        {
            // Load presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through slides and shapes
            foreach (var slide in presentation.Slides)
            {
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.OleObjectFrame oleFrame)
                    {
                        // Determine decorative status
                        var isDecorative = oleFrame.IsDecorative;
                        Console.WriteLine($"Slide {slide.SlideNumber}, Shape \"{shape.Name}\": IsDecorative = {isDecorative}");
                    }
                }
            }

            // Save presentation before exit
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}