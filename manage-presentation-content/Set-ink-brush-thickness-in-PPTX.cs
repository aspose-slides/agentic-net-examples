using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first shape on the first slide as an Ink object
        Aspose.Slides.Ink.IInk ink = pres.Slides[0].Shapes[0] as Aspose.Slides.Ink.IInk;
        if (ink != null && ink.Traces.Length > 0)
        {
            // Get the brush of the first ink trace and set its size (width, height) in points
            Aspose.Slides.Ink.IInkBrush brush = ink.Traces[0].Brush;
            brush.Size = new SizeF(5f, 10f);
        }
        else
        {
            Console.WriteLine("No ink shape with traces found.");
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}