using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output files
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a line shape as a base for an ink annotation
        Aspose.Slides.IShape baseShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line,   // Use a line shape (Ink is not a ShapeType)
            100, 100,                       // X and Y position
            300, 0);                        // Width and Height (horizontal line)

        // Cast the shape to an Ink object to work with ink-specific features
        Aspose.Slides.Ink.Ink inkShape = baseShape as Aspose.Slides.Ink.Ink;
        if (inkShape != null)
        {
            // Example: set the line thickness of the ink shape
            inkShape.Width = 5;
            inkShape.Height = 5;
        }

        // Save the modified presentation as PPTX using the correct SaveFormat enum
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}