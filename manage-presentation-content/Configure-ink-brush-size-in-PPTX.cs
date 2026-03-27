using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Cast the first shape to an Ink object
            Aspose.Slides.Ink.Ink inkShape = slide.Shapes[0] as Aspose.Slides.Ink.Ink;
            if (inkShape != null)
            {
                Aspose.Slides.Ink.IInkTrace[] traces = inkShape.Traces;
                if (traces.Length > 0)
                {
                    Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;
                    // Set the brush size (width, height) in points
                    brush.Size = new SizeF(5f, 10f);
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}