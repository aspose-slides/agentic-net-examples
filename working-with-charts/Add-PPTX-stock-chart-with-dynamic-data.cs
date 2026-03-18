using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a High-Low-Close stock chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.HighLowClose,
                0f, 0f, 500f, 400f);

            // Enable chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Dynamic Stock Chart");

            // Enable varied colors for the first series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            series.ParentSeriesGroup.IsColorVaried = true;

            // Save the presentation
            presentation.Save("DynamicStockChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}