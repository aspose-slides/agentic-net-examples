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

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Access the first series in the chart
        IChartSeries series = chart.ChartData.Series[0];

        // Modify the GapWidth via the parent series group (value is a percentage of bar width)
        IChartSeriesGroup seriesGroup = series.ParentSeriesGroup;
        seriesGroup.GapWidth = 150; // Example: 150%

        // Save the presentation
        presentation.Save("SeriesGapWidth_out.pptx", SaveFormat.Pptx);
    }
}