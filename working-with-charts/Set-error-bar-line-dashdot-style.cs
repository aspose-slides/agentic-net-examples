using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a line chart (scatter with smooth lines)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
            0, 0, 500, 400);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Make Y error bars visible
        series.ErrorBarsYFormat.IsVisible = true;

        // Set the dash style of the error bar line to DashDot
        series.ErrorBarsYFormat.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.DashDot;

        // Save the presentation
        pres.Save("ErrorBarsDashDot.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}