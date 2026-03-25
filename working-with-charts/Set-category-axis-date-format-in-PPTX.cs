using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add an Area chart to the first slide
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Area, 50f, 50f, 500f, 400f);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

            // Clear default data
            wb.Clear(0);
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Add date categories
            chart.ChartData.Categories.Add(
                wb.GetCell(0, "A2", System.DateTime.Parse("2023-01-01").ToOADate()));
            chart.ChartData.Categories.Add(
                wb.GetCell(0, "A3", System.DateTime.Parse("2023-02-01").ToOADate()));
            chart.ChartData.Categories.Add(
                wb.GetCell(0, "A4", System.DateTime.Parse("2023-03-01").ToOADate()));
            chart.ChartData.Categories.Add(
                wb.GetCell(0, "A5", System.DateTime.Parse("2023-04-01").ToOADate()));

            // Add a line series and its data points
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.Line);
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 10));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 20));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 15));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 25));

            // Configure the category axis as a date axis with a custom format
            chart.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;
            chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
            chart.Axes.HorizontalAxis.NumberFormat = "dd-MMM-yyyy";

            // Save the presentation
            string outputPath = "DateAxisChart.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}