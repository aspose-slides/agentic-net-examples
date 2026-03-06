using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetCategoryAxisDateFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add an Area chart (the type can be changed as needed)
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Area, 50, 50, 500, 400);

            // Get the workbook that holds chart data
            Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

            // Clear any existing data
            wb.Clear(0);
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Add date categories (Excel stores dates as OLE Automation dates)
            chart.ChartData.Categories.Add(wb.GetCell(0, "A2", System.DateTime.Parse("2023-01-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A3", System.DateTime.Parse("2023-02-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A4", System.DateTime.Parse("2023-03-01").ToOADate()));
            chart.ChartData.Categories.Add(wb.GetCell(0, "A5", System.DateTime.Parse("2023-04-01").ToOADate()));

            // Add a line series and populate it with values
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Line);
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 10));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 20));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 30));
            series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 40));

            // Configure the horizontal axis to treat categories as dates
            chart.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;
            chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
            chart.Axes.HorizontalAxis.NumberFormat = "dd-MMM-yyyy";

            // Save the presentation
            string outputPath = "SetCategoryAxisDateFormat_out.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}