using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Access the first slide and the first shape (assumed to be a chart)
        ISlide slide = presentation.Slides[0];
        IShape shape = slide.Shapes[0];
        IChart chart = shape as IChart;
        if (chart == null)
        {
            Console.WriteLine("No chart found on the first slide.");
            return;
        }

        // Get the first series of the chart
        IChartSeries series = chart.ChartData.Series[0];

        // Set the series fill type to solid and define a base color
        series.Format.Fill.FillType = FillType.Solid;
        series.Format.Fill.SolidFillColor.Color = Color.Blue;

        // Configure the inverted solid fill color for the series
        series.InvertedSolidFillColor.Color = Color.Yellow;

        // Optional: enable inversion when values are negative
        series.InvertIfNegative = true;

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}