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

        // Iterate through shapes on the first slide
        foreach (Aspose.Slides.IShape shape in presentation.Slides[0].Shapes)
        {
            // Check if the shape is an Ink object
            if (shape is Aspose.Slides.Ink.Ink)
            {
                Aspose.Slides.Ink.Ink inkShape = (Aspose.Slides.Ink.Ink)shape;

                // Get all ink traces
                Aspose.Slides.Ink.IInkTrace[] traces = inkShape.Traces;

                // Set the brush color for each trace
                foreach (Aspose.Slides.Ink.IInkTrace trace in traces)
                {
                    Aspose.Slides.Ink.IInkBrush brush = trace.Brush;
                    brush.Color = Color.Red;
                }
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}