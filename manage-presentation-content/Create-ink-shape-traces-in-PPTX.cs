using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Retrieve the first shape as an Ink object
            var inkShape = pres.Slides[0].Shapes[0] as Aspose.Slides.Ink.IInk;
            if (inkShape == null)
            {
                Console.WriteLine("No Ink shape found on the first slide.");
                return;
            }

            // Access ink traces
            var traces = inkShape.Traces;
            Console.WriteLine($"Number of ink traces: {traces.Length}");

            // Example: display point count of the first trace
            if (traces.Length > 0)
            {
                var points = traces[0].Points;
                Console.WriteLine($"First trace contains {points.Length} points.");
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}