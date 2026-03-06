using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

        // Access the first series in the chart
        IChartSeries series = chart.ChartData.Series[0];

        // Set the series gap width (percentage of bar/column width)
        series.ParentSeriesGroup.GapWidth = 150; // Example: 150%

        // Save the presentation
        presentation.Save("SetSeriesGapWidth_out.pptx", SaveFormat.Pptx);
    }
}