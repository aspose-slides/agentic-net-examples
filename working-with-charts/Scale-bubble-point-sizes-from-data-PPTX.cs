using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var outputPath = "BubbleChart.pptx";

            var pres = new Aspose.Slides.Presentation();
            var slide = pres.Slides[0];
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Adjust bubble scaling and representation
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // 150%
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            var series = chart.ChartData.Series[0];
            // Add data points with X, Y, and bubble size values
            series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 10.0);
            series.DataPoints.AddDataPointForBubbleSeries(2.0, 3.0, 20.0);
            series.DataPoints.AddDataPointForBubbleSeries(3.0, 1.5, 5.0);

            // Show bubble size in data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}