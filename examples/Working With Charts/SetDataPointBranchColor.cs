using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetDataPointBranchColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a Treemap chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 50, 50, 500, 400);

            // Get the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Ensure the series has at least one data point
            if (series.DataPoints.Count == 0)
            {
                // Add a sample data point (value 10)
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "B2", 10));
            }

            // Get the first data point
            IChartDataPoint dataPoint = series.DataPoints[0];

            // Get the first data point level (branch) and set its fill color
            IChartDataPointLevel level = dataPoint.DataPointLevels[0];
            level.Format.Fill.FillType = FillType.Solid;
            level.Format.Fill.SolidFillColor.Color = Color.Green;

            // Save the presentation
            presentation.Save("SetDataPointBranchColor_out.pptx", SaveFormat.Pptx);
        }
    }
}