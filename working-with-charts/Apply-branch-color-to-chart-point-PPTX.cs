using System;
using System.IO;
using System.Drawing;
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

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Add a Sunburst chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Sunburst, 50f, 50f, 500f, 400f);

        // Access the data points of the first series
        Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

        // Select a specific data point (e.g., index 3) and assign a branch color
        Aspose.Slides.Charts.IChartDataPoint dataPoint = dataPoints[3];
        dataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        dataPoint.Format.Fill.SolidFillColor.Color = Color.Yellow; // specific branch color

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}