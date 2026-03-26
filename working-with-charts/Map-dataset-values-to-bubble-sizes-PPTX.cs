using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "BubbleChart.pptx";

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Add a bubble chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Get the first (and only) series of the bubble chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure the data source types to accept literal double values
            series.DataPoints.DataSourceTypeForXValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForYValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForBubbleSizes = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Sample dataset: X values, Y values, and bubble sizes
            double[] xValues = new double[] { 1.0, 2.0, 3.0, 4.0 };
            double[] yValues = new double[] { 10.0, 20.0, 30.0, 40.0 };
            double[] bubbleSizes = new double[] { 5.0, 15.0, 25.0, 35.0 };

            // Populate the series with data points
            for (int i = 0; i < xValues.Length; i++)
            {
                series.DataPoints.AddDataPointForBubbleSeries(xValues[i], yValues[i], bubbleSizes[i]);
            }

            // Save the presentation to disk
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}