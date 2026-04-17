using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;
using System.Drawing;

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
            using (Presentation pres = new Presentation(inputPath))
            {
                if (pres.Slides.Count == 0)
                {
                    Console.WriteLine("No slides in presentation.");
                    return;
                }

                // Assume the first shape on the first slide is an Ink shape
                IShape shape = pres.Slides[0].Shapes[0];
                Ink inkShape = shape as Ink;
                if (inkShape == null)
                {
                    Console.WriteLine("First shape is not an Ink shape.");
                    return;
                }

                if (inkShape.Traces.Length == 0)
                {
                    Console.WriteLine("Ink shape has no traces.");
                    return;
                }

                IInkBrush brush = inkShape.Traces[0].Brush;
                // Set brush size (width, height) in points
                brush.Size = new SizeF(5f, 10f);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}