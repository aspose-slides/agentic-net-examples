using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using System.Drawing;

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

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the first Ink shape on the first slide (adjust indices as needed)
        Aspose.Slides.Ink.Ink inkShape = presentation.Slides[0].Shapes[0] as Aspose.Slides.Ink.Ink;
        if (inkShape != null && inkShape.Traces.Length > 0)
        {
            // Get the brush of the first trace and set its color
            Aspose.Slides.Ink.IInkBrush brush = inkShape.Traces[0].Brush;
            brush.Color = Color.Blue;
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}