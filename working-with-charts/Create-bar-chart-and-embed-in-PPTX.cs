using System;
using Aspose.Slides.Export;

namespace AsposeSlidesBarChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart (bar chart) to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 100f, 100f, 500f, 400f);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            Aspose.Slides.Charts.IChartCategory category;
            category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A1", "Category 1"));
            category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A2", "Category 2"));
            category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A3", "Category 3"));

            // Add first series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, "B1", "Series 1"),
                Aspose.Slides.Charts.ChartType.ClusteredColumn);
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B2", 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B3", 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B4", 30));

            // Add second series
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, "C1", "Series 2"),
                Aspose.Slides.Charts.ChartType.ClusteredColumn);
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "C2", 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "C3", 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "C4", 60));

            // Save the presentation
            presentation.Save("BarChartOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}