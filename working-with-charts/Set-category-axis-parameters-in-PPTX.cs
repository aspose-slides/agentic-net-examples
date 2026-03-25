using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            var chart = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                chart.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;
                chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
                chart.Axes.HorizontalAxis.MajorUnit = 1.0;
                chart.Axes.HorizontalAxis.MajorUnitScale = Aspose.Slides.Charts.TimeUnitType.Months;
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}