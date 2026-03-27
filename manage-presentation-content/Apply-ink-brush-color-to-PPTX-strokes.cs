using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using System.Drawing;

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

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        if (pres.Slides.Count > 0 && pres.Slides[0].Shapes.Count > 0)
        {
            Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];
            Aspose.Slides.Ink.Ink ink = shape as Aspose.Slides.Ink.Ink;
            if (ink != null)
            {
                Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;
                foreach (Aspose.Slides.Ink.IInkTrace trace in traces)
                {
                    Aspose.Slides.Ink.IInkBrush brush = trace.Brush;
                    brush.Color = Color.Blue;
                }
            }
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}