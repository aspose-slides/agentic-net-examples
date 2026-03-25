using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

            // Set position axis property (AxisBetweenCategories)
            chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

            // Show display unit label on vertical axis (Millions)
            chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add series
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

            // Populate first series data points
            Aspose.Slides.Charts.IChartSeries series0 = chart.ChartData.Series[0];
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            // Populate second series data points
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[1];
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

            // Set series overlap if default (0)
            Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;
            if (seriesCollection[0].Overlap == 0)
            {
                seriesCollection[0].ParentSeriesGroup.Overlap = 55; // 55% overlap
            }

            // Save the presentation
            string outputPath = "ClusteredColumnChart.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}