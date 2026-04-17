using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                if (pres.Slides.Count == 0 || pres.Slides[0].Shapes.Count == 0)
                {
                    Console.WriteLine("Presentation does not contain slides or shapes.");
                    return;
                }

                var shape = pres.Slides[0].Shapes[0];
                var lineFormat = shape.LineFormat;
                Aspose.Slides.LineDashStyle originalDash = lineFormat.DashStyle;

                Aspose.Slides.ILineFormatEffectiveData effectiveLine = lineFormat.GetEffective();
                Aspose.Slides.LineDashStyle effectiveDash = effectiveLine.DashStyle;

                Console.WriteLine("Original DashStyle: " + originalDash);
                Console.WriteLine("Effective DashStyle after theme: " + effectiveDash);

                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}