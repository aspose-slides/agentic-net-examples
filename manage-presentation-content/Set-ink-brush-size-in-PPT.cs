using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace AdjustInkBrushSize
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Find the first ink shape on the first slide
            IInk inkShape = null;
            foreach (IShape shape in pres.Slides[0].Shapes)
            {
                inkShape = shape as IInk;
                if (inkShape != null)
                {
                    break;
                }
            }

            if (inkShape == null)
            {
                Console.WriteLine("No ink shape found in the presentation.");
                pres.Dispose();
                return;
            }

            // Adjust brush size for each ink trace
            IInkTrace[] traces = inkShape.Traces;
            foreach (IInkTrace trace in traces)
            {
                IInkBrush brush = trace.Brush;
                // Set new brush size (width, height) in points
                brush.Size = new SizeF(5f, 5f);
            }

            // Save the modified presentation
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output.pptx");
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();

            Console.WriteLine("Presentation saved with updated ink brush size: " + outputPath);
        }
    }
}