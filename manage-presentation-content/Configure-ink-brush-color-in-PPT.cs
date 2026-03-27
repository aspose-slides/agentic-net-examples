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
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        using (Presentation pres = new Presentation(inputPath))
        {
            Aspose.Slides.Ink.Ink inkShape = pres.Slides[0].Shapes[0] as Aspose.Slides.Ink.Ink;
            if (inkShape != null && inkShape.Traces.Length > 0)
            {
                IInkBrush brush = inkShape.Traces[0].Brush;
                brush.Color = Color.Blue;
            }

            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}