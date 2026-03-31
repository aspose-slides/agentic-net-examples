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
                // Assume the first shape on the first slide is an Ink object
                Ink inkShape = pres.Slides[0].Shapes[0] as Ink;
                if (inkShape != null && inkShape.Traces.Length > 0)
                {
                    IInkBrush brush = inkShape.Traces[0].Brush;
                    brush.Size = new SizeF(5f, 10f);
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URL issues)
        }
    }
}