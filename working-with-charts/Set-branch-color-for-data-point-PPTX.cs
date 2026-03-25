using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Retrieve the first chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
        if (chart == null)
        {
            Console.WriteLine("No chart found on the first slide.");
            return;
        }

        // Access the data points collection of the first series
        Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

        // Select a specific data point (e.g., index 3)
        Aspose.Slides.Charts.IChartDataPoint dataPoint = dataPoints[3];

        // For Sunburst or hierarchical charts, set the branch color via the data point level format
        // Here we set the fill color directly on the data point
        dataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        dataPoint.Format.Fill.SolidFillColor.Color = Color.Yellow;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}