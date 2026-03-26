using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        var pres = new Presentation(inputPath);
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            var slide = pres.Slides[i];
            for (int j = 0; j < slide.Shapes.Count; j++)
            {
                var shape = slide.Shapes[j];
                if (shape is Aspose.Slides.Charts.IChart chart)
                {
                    chart.ValidateChartLayout();
                    var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
                    Console.WriteLine($"Slide {i + 1}, Chart {j + 1}: Vertical Axis Max = {maxValue}");
                }
            }
        }

        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}