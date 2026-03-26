using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;
        Aspose.Slides.Charts.IChart chart = shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

        // Optional: set how bubble sizes are represented (by width)
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Get the first (and only) series created by default
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Configure data source types to use literal double values for X, Y and bubble size
        series.DataPoints.DataSourceTypeForXValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        series.DataPoints.DataSourceTypeForYValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
        series.DataPoints.DataSourceTypeForBubbleSizes = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

        // Add data points: (X, Y, BubbleSize)
        series.DataPoints.AddDataPointForBubbleSeries(1.0, 4.0, 10.0);
        series.DataPoints.AddDataPointForBubbleSeries(2.0, 5.0, 20.0);
        series.DataPoints.AddDataPointForBubbleSeries(3.0, 2.0, 15.0);
        series.DataPoints.AddDataPointForBubbleSeries(4.0, 7.0, 25.0);

        // Save the presentation to disk
        presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}