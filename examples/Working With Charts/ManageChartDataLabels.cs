using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace ChartDataLabelsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Data");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

            // Access the first series in the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Show series name in all data labels of this series
            series.Labels.DefaultDataLabelFormat.ShowSeriesName = true;

            // Show value in all data labels of this series
            series.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Change the separator used between label parts
            series.Labels.DefaultDataLabelFormat.Separator = " - ";

            // Hide all data labels for the second series (if it exists)
            if (chart.ChartData.Series.Count > 1)
            {
                IChartSeries secondSeries = chart.ChartData.Series[1];
                secondSeries.Labels.Hide();
            }

            // Add custom text to the first data point label of the first series
            IDataLabel firstPointLabel = series.DataPoints[0].Label;
            firstPointLabel.AddTextFrameForOverriding("Target Achieved");

            // Optionally change the text color of the custom label
            firstPointLabel.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
            firstPointLabel.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save("ChartDataLabels_out.pptx", SaveFormat.Pptx);
        }
    }
}