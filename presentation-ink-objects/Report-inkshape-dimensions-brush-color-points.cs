using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main(string[] args)
    {
        var inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }
        try
        {
            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    var slide = pres.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        var shape = slide.Shapes[j];
                        if (shape is Aspose.Slides.Ink.IInk ink)
                        {
                            Console.WriteLine($"Slide {i + 1}, Ink Shape {j + 1}:");
                            Console.WriteLine($"  Position: X={ink.X}, Y={ink.Y}, Width={ink.Width}, Height={ink.Height}");
                            var traces = ink.Traces;
                            Console.WriteLine($"  Traces count: {traces.Length}");
                            for (int t = 0; t < traces.Length; t++)
                            {
                                var trace = traces[t];
                                var points = trace.Points;
                                Console.WriteLine($"    Trace {t + 1} points: {points.Length}");
                                var brush = trace.Brush;
                                Console.WriteLine($"    Brush color: {brush.Color}");
                            }
                        }
                    }
                }
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}