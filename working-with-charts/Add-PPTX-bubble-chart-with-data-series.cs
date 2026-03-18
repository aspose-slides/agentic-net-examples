using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400);
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Bubble Chart");

                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Bubble);
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));
                series1.DataPoints.AddDataPointForBubbleSeries(1, 2, 30);
                series1.DataPoints.AddDataPointForBubbleSeries(2, 3, 40);
                series1.DataPoints.AddDataPointForBubbleSeries(3, 4, 50);
                series1.ParentSeriesGroup.IsColorVaried = true;

                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), Aspose.Slides.Charts.ChartType.Bubble);
                series2.DataPoints.AddDataPointForBubbleSeries(1.5, 2.5, 35);
                series2.DataPoints.AddDataPointForBubbleSeries(2.5, 3.5, 45);
                series2.DataPoints.AddDataPointForBubbleSeries(3.5, 4.5, 55);
                series2.ParentSeriesGroup.IsColorVaried = true;

                pres.Save("BubbleChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}