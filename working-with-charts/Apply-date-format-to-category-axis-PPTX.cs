using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CategoryAxisDateFormatExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add an Area chart to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50f, 50f, 600f, 400f);

            // Get the chart data workbook
            IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

            // Clear any existing data
            wb.Clear(0);
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Add date categories
            chart.ChartData.Categories.Add(wb.GetCell(0, "A2", DateTime.Parse("2023-01-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A3", DateTime.Parse("2023-02-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A4", DateTime.Parse("2023-03-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A5", DateTime.Parse("2023-04-01").ToOADate()));

            // Add a line series and populate it with values
            IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 10));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 20));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 30));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 40));

            // Configure the horizontal axis as a date axis with a custom number format
            chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
            chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
            chart.Axes.HorizontalAxis.NumberFormat = "dd-MMM-yyyy";

            // Save the presentation
            string outputPath = "CategoryAxisDateFormat_out.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}