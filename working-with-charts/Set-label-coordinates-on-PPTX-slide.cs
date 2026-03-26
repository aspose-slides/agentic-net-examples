using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation from the input file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Adjust positions of shapes (labels) on each slide as needed
        foreach (Aspose.Slides.ISlide slide in pres.Slides)
        {
            // Example: move each shape to a new coordinate (replace with actual logic)
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Set new X and Y coordinates (example values)
                shape.X = 100f; // new X position in points
                shape.Y = 150f; // new Y position in points
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}