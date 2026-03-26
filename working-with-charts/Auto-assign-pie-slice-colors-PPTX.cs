using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace PieChartAutomaticColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

            // Set chart title
            chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 20f;
            chart.HasTitle = true;

            // Show values on data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Product A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Product B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Product C"));

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Sales"), chart.Type);

            // Add data points
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 45));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 25));

            // Enable automatic varied colors for each slice
            series.ParentSeriesGroup.IsColorVaried = true;

            // Save the presentation
            presentation.Save("AutomaticPieColors.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}