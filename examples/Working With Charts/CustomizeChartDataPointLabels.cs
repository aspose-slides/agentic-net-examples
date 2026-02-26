using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace ChartDataPointLabelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Access the first series in the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Customize the label of the first data point
            IChartDataPoint firstPoint = series.DataPoints[0];
            IDataLabel firstLabel = firstPoint.Label;
            firstLabel.DataLabelFormat.ShowCategoryName = true;
            firstLabel.DataLabelFormat.ShowValue = true;
            firstLabel.DataLabelFormat.NumberFormat = "0.00%";

            // Customize the label of the second data point
            IChartDataPoint secondPoint = series.DataPoints[1];
            IDataLabel secondLabel = secondPoint.Label;
            secondLabel.DataLabelFormat.ShowSeriesName = true;
            secondLabel.DataLabelFormat.ShowValue = true;
            secondLabel.DataLabelFormat.Separator = " - ";

            // Change the text color of the second data point label
            secondLabel.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
            secondLabel.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

            // Save the presentation
            presentation.Save("CustomDataPointLabels_out.pptx", SaveFormat.Pptx);
        }
    }
}