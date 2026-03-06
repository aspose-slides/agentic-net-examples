using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace FormatPresentationCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Iterate through each series and each data point to set a number format (e.g., 0.00%)
            Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;
            foreach (Aspose.Slides.Charts.ChartSeries seriesItem in seriesCollection)
            {
                foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in seriesItem.DataPoints)
                {
                    // Set preset number format to 0.00% (preset number 10)
                    dataPoint.Value.AsCell.PresetNumberFormat = 10;
                }
            }

            // Save the presentation
            presentation.Save("FormattedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}