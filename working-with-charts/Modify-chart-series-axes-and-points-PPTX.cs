using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart != null)
        {
            // Change the data range of the chart
            chart.ChartData.SetRange("Sheet1!$A$1:$B$5");

            // Customize data labels for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

            // Set horizontal axis label offset
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)10;

            // Remove the second data point from the first series, if it exists
            Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
            if (dataPoints.Count > 1)
            {
                Aspose.Slides.Charts.IChartDataPoint pointToRemove = dataPoints[1];
                pointToRemove.Remove();
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}