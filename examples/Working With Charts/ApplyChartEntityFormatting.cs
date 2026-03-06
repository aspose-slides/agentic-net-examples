using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyChartEntityFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Apply number format to all data points (e.g., percentage format)
            Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;
            foreach (Aspose.Slides.Charts.ChartSeries seriesItem in seriesCollection)
            {
                foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in seriesItem.DataPoints)
                {
                    // 10 corresponds to the built‑in preset format "0.00%" in PowerPoint
                    dataPoint.Value.AsCell.PresetNumberFormat = 10;
                }
            }

            // Show display unit label (e.g., millions) on the vertical axis
            chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

            // Customize data labels for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

            // Save the presentation
            presentation.Save("FormattedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}