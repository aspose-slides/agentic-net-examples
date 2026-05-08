using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            var outputPath = "DateAxisFormatted.pptx";

            // Create a new presentation
            var pres = new Presentation();

            // Add an Area chart to the first slide
            var chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50f, 50f, 500f, 400f);

            // Access the chart data workbook
            var wb = chart.ChartData.ChartDataWorkbook;

            // Clear any existing data
            wb.Clear(0);
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Add date categories
            chart.ChartData.Categories.Add(wb.GetCell(0, "A2", DateTime.Parse("2023-01-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A3", DateTime.Parse("2023-02-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A4", DateTime.Parse("2023-03-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A5", DateTime.Parse("2023-04-01").ToOADate()));

            // Add a line series with values
            var series = chart.ChartData.Series.Add(ChartType.Line);
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 10));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 20));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 30));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 40));

            // Set the category axis to date type and apply custom date format
            chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
            chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
            chart.Axes.HorizontalAxis.NumberFormat = "dd-MMM-yyyy";

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}