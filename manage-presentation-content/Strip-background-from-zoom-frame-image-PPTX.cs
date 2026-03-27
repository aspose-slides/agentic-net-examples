using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Locate the second zoom frame on the first slide
        IZoomFrame secondZoomFrame = null;
        int zoomFrameIndex = 0;
        foreach (IShape shape in presentation.Slides[0].Shapes)
        {
            if (shape is IZoomFrame)
            {
                zoomFrameIndex++;
                if (zoomFrameIndex == 2)
                {
                    secondZoomFrame = (IZoomFrame)shape;
                    break;
                }
            }
        }

        // If the second zoom frame is found, strip its background
        if (secondZoomFrame != null)
        {
            secondZoomFrame.ShowBackground = false;
        }
        else
        {
            Console.WriteLine("Second zoom frame not found.");
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}