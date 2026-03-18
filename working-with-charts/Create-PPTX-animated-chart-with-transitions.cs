using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

namespace AnimatedChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (var presentation = new Aspose.Slides.Presentation())
                {
                    // Access the first slide
                    var slide = presentation.Slides[0];

                    // Add a clustered column chart
                    var chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.ClusteredColumn,
                        50, 50, 500, 400);

                    // Set chart title
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Sales Overview");

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Get the chart data workbook
                    var workbook = chart.ChartData.ChartDataWorkbook;
                    var defaultWorksheetIndex = 0;

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Q4"));

                    // Add series
                    var series1 = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 1, "Product A"),
                        chart.Type);
                    var series2 = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 2, "Product B"),
                        chart.Type);

                    // Populate series data
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 120));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 150));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 170));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 200));

                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 80));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 130));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 160));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 190));

                    // Add animation: animate each series by fly effect from left on click
                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                        0,
                        Aspose.Slides.Animation.EffectType.Fly,
                        Aspose.Slides.Animation.EffectSubtype.Left,
                        Aspose.Slides.Animation.EffectTriggerType.OnClick);

                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                        1,
                        Aspose.Slides.Animation.EffectType.Fly,
                        Aspose.Slides.Animation.EffectSubtype.Right,
                        Aspose.Slides.Animation.EffectTriggerType.OnClick);

                    // Save the presentation
                    presentation.Save("AnimatedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}