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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        using (Presentation pres = new Presentation(inputPath))
        {
            foreach (ISlide slide in pres.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    Ink inkShape = shape as Ink;
                    if (inkShape != null)
                    {
                        foreach (IInkTrace trace in inkShape.Traces)
                        {
                            IInkBrush brush = trace.Brush;
                            brush.Size = new SizeF(5f, 5f); // Set stroke thickness
                        }
                    }
                }
            }

            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}