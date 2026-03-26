using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace InsertAndRemoveSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a new chart (initialized with sample data)
            IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add new series using cell for series name
            IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.ClusteredColumn);
            IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), Aspose.Slides.Charts.ChartType.ClusteredColumn);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Populate data for Series 1
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));
            series1.Format.Fill.FillType = FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Red;

            // Populate data for Series 2
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));
            series2.Format.Fill.FillType = FillType.Solid;
            series2.Format.Fill.SolidFillColor.Color = Color.Green;

            // Remove the second series (as an example of deleting unwanted series)
            chart.ChartData.Series.Remove(series2);

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}