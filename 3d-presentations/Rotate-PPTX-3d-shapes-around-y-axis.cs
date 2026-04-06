using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var presentation = new Presentation(inputPath);
            foreach (var slide in presentation.Slides)
            {
                foreach (var shape in slide.Shapes)
                {
                    // Apply 45-degree rotation around Y-axis
                    shape.ThreeDFormat.Camera.SetRotation(0, 45, 0);
                }
            }

            // Ensure output directory exists
            var outDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}