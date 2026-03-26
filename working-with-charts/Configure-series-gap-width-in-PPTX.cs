using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a stacked column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.StackedColumn, 50f, 50f, 500f, 400f);

        // Set the gap width for the first series group
        Aspose.Slides.Charts.IChartSeries series0 = chart.ChartData.Series[0];
        series0.ParentSeriesGroup.GapWidth = 150; // Gap width as a percentage of bar width

        // Save the presentation
        string outputPath = "SeriesGapWidth.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}