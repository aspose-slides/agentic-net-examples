using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "BubbleChart.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide (created by default)
        ISlide slide = pres.Slides[0];

        // Add a bubble chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400);

        // Get the first series of the chart
        IChartSeries series = chart.ChartData.Series[0];

        // Configure the data point collection to accept double literals for X, Y and bubble size
        series.DataPoints.DataSourceTypeForXValues = DataSourceType.DoubleLiterals;
        series.DataPoints.DataSourceTypeForYValues = DataSourceType.DoubleLiterals;
        series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

        // Sample data values
        double[] xValues = new double[] { 1.0, 2.0, 3.0 };
        double[] yValues = new double[] { 4.0, 5.0, 6.0 };
        double[] bubbleSizes = new double[] { 10.0, 20.0, 30.0 };

        // Add data points to the bubble series
        for (int i = 0; i < xValues.Length; i++)
        {
            series.DataPoints.AddDataPointForBubbleSeries(xValues[i], yValues[i], bubbleSizes[i]);
        }

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}